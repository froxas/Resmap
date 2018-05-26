using Microsoft.EntityFrameworkCore;
using System;

namespace Resmap.API.Data
{
    public class ApplicationDbContext : DbContext
    {         
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relation>().HasQueryFilter(p => !p.IsDeleted);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Relation> Relations { get; set; }       
    }
}
