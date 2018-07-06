using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Resmap.Data
{
    public class ApplicationDbContext : DbContext
    {
        private Guid _teanantId;
        
        private readonly IEntityTypeProvider _entityTypeProvider;      

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ITenantProvider tenantProvider,
            IEntityTypeProvider entityTypeProvider) 
            : base(options)
        {
            _teanantId = tenantProvider.GetTenantId();
            _entityTypeProvider = entityTypeProvider;
        }
             

        #region DbSets
        public DbSet<Employee> Employees { get; set; }        
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<CarEvent> CarEvents { get; set; }
        public DbSet<EmployeeEvent> EmployeeEvents { get; set; }
        public DbSet<Tag> Tags { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory); // Warning: Do not create a new ILoggerFactory instance each time                
                //.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFLogging;Trusted_Connection=True;ConnectRetryCount=0");
        }

       
        public static readonly LoggerFactory MyLoggerFactory
               = new LoggerFactory(new[]
               {                   
                    new ConsoleLoggerProvider((category, level)
                        => category == DbLoggerCategory.Database.Command.Name //Command.Name
                           && level == LogLevel.Information, true)
               });


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region entities configuration
            
            modelBuilder.Entity<ProjectTag>()
                .HasKey(t => new { t.ProjectId, t.TagId });
                        
            #endregion

            foreach (var type in _entityTypeProvider.GetEntityTypes())
            {
                var method = SetGlobalQueryMethod.MakeGenericMethod(type);
                method.Invoke(this, new object[] { modelBuilder });
            }

            base.OnModelCreating(modelBuilder);

            #region Soft delete configuration
            /*
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {                             
                
                // 1. Add the IsDeleted property
                entityType.GetOrAddProperty("IsDeleted", typeof(bool));

                // 2. Create the query filter
                var parameter = Expression.Parameter(entityType.ClrType);

                // EF.Property<bool>(post, "IsDeleted")
                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsDeleted"));

                // EF.Property<bool>(post, "IsDeleted") == false
                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));

                // post => EF.Property<bool>(post, "IsDeleted") == false
                var lambda = Expression.Lambda(compareExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);    
            }
            */
            #endregion                                       
                
        }

        public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>().HasKey(e => e.Id);
            Debug.WriteLine("Adding global query for: " + typeof(T));
            builder.Entity<T>().HasQueryFilter(e => e.TenantId == _teanantId && !e.IsDeleted);
        }

        static readonly MethodInfo SetGlobalQueryMethod 
            = typeof(ApplicationDbContext)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");
             
                
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {            
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
       
        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Overiding OnBeforeSaving in order to implement 
        /// soft delete and tenant colums & filters
        /// </summary>
        private void OnBeforeSaving()
        {            
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        entry.CurrentValues["TenantId"] = _teanantId;
                        break;

                    case EntityState.Deleted:
                        HandleDependent(entry);
                        ProcessEntities(entry);                       
                        break;
                }
            }
        }

        #region Cascade on a soft delete
        
        private void HandleDependent(EntityEntry entry)
        {            
            entry.State = EntityState.Modified;
            entry.CurrentValues["IsDeleted"] = true;
        }
       
        /// <summary>
        /// Process all dependent entities and handles it with HandleDependent()
        /// </summary>
        /// <param name="entry"></param>
        private void ProcessEntities(EntityEntry entry)
        {
            foreach (var navigationEntry in entry.Navigations)
            {
                if (navigationEntry is CollectionEntry collectionEntry)
                {
                    foreach (var dependentEntry in collectionEntry.CurrentValue)
                    {
                        HandleDependent(Entry(dependentEntry));
                    }
                }
                else
                {
                    var dependentEntry = navigationEntry.CurrentValue;
                    if (dependentEntry != null)
                    {
                        HandleDependent(Entry(dependentEntry));
                    }
                }
            }
        }
        #endregion

       
    }    
}

