using System;
using System.Linq;

namespace Resmap.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // look for employees
            if (!context.Employees.Any())
            {
                var employees = new Employee[]
                   {
                new Employee
                {
                    Id = Guid.NewGuid(),
                    EmployeeID ="1101",
                    FirstName ="Vaidas",
                    LastName ="Brazionis",
                    JobTitle ="Developer",
                    Department ="Development",
                    IsSubcontractor =false,
                    Address = new Address
                    {
                        Id = Guid.NewGuid(),
                        City = "Klaipeda",
                        Country = "Lietuva",
                        Street = "Minijos",
                        House = "180",
                        PostCode = "LT-91233"
                    }
                },
                new Employee {Id = Guid.NewGuid(), EmployeeID="1102", FirstName="Domas", LastName="Zemaitis", JobTitle="System architect", Department="Development", IsSubcontractor=false},
                new Employee {Id = Guid.NewGuid(), EmployeeID="1103", FirstName="Jonas", LastName="Jonauskas", JobTitle="Developer", Department="Development", IsSubcontractor=false},
                new Employee {Id = Guid.NewGuid(), EmployeeID="1104", FirstName="Algis", LastName="Greitai", JobTitle="Manager", Department="HR", IsSubcontractor=false},
                  };
                context.AddRange(employees);
                context.SaveChanges();
            }

            if (!context.JobTitles.Any())
            {
                var jobtitles = new JobTitle[]
                  {
                new JobTitle {Id=Guid.NewGuid(), Title="Developer"},
                new JobTitle {Id=Guid.NewGuid(), Title="System architect"},
                new JobTitle {Id=Guid.NewGuid(), Title="Manager"}
                 };
                context.AddRange(jobtitles);
                context.SaveChanges();
            }

            if (!context.Departments.Any())
            {
                var departments = new Department[]
            {
                new Department {Id=Guid.NewGuid(), Title="Development"},
                new Department {Id=Guid.NewGuid(), Title="HR"},
                new Department {Id=Guid.NewGuid(), Title="Marketing"},
                new Department {Id=Guid.NewGuid(), Title="Support"}
            };
                context.AddRange(departments);
                context.SaveChanges();
            }

            if (!context.Relations.Any())
            {
                var relations = new Relation[]
                {
                new Relation {
                    Id =Guid.NewGuid(),
                    RelationId ="33214526",
                    Title ="Flinke Folk",
                    Address = new Address
                    {
                        Id = Guid.NewGuid(),
                        City = "Slengiai",
                        Country = "Lietuva",
                        Street = "Juknaiciu",
                        House = "23",
                        PostCode = "LT-91233"
                    }
                },
                new Relation {Id=Guid.NewGuid(), RelationId="11123364", Title="Exadel"},
                new Relation {Id=Guid.NewGuid(), Title="Hertel BV"},
                new Relation {Id=Guid.NewGuid(), Title="Altrad"}
                };
                context.AddRange(relations);
                context.SaveChanges();
            }
                                    
        }
    }
}
