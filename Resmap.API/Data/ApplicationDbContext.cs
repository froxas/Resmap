using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Resmap.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Relation> Relations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // 1. Add the IsDeleted property
                //entityType.GetOrAddProperty("IsDeleted", typeof(bool));

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
        }
    }
}

