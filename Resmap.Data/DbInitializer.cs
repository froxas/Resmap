using RandomNameGeneratorLibrary;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resmap.Data
{
    public static class DbInitializer
    {
        static Random rnd = new Random();

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            string[] jobTitlesArray = new string[] { "Developer", "Architect", "Manager", "Designer" };
            string[] departmentsArray = new string[] { "Design", "Development", "Offshore", "Sales" };
            Employee[] employees = new Employee[65];            
            DateTime startDate = DateTime.UtcNow.AddDays(-60);

            #region Employees            
            if (!context.Employees.Any())
            {
                var personGenerator = new PersonNameGenerator();

                for (int i = 0; i < employees.Length; i++)
                {
                    employees[i] = new Employee
                    {
                        Id = Guid.NewGuid(),
                        EmployeeID = rnd.Next(1, 9999).ToString(),
                        FirstName = personGenerator.GenerateRandomFirstName(),
                        LastName = personGenerator.GenerateRandomLastName(),
                        JobTitle = jobTitlesArray[rnd.Next(4)],
                        Department = departmentsArray[rnd.Next(4)],
                        IsSubcontractor = false,
                    };
                }
                context.AddRange(employees);
                context.SaveChanges();
            }
            #endregion

            // event generator
            if (!context.Events.Any())
            {
                List<Event> events = new List<Event>();

                for (int i = 0; i < employees.Length; i++)
                {
                    var amount = rnd.Next(10);
                    var date = startDate;
                    for (int j = 0; j < amount; j++)
                    {
                        var e = EventGenerator(employees[i].Id, date);
                        events.Add(e);
                        date = e.Till;
                        e = null;                        
                    }
                }
                context.AddRange(events);
                context.SaveChanges();
            }

            #region JobTitles
            if (!context.JobTitles.Any())
            {
                var lenght = jobTitlesArray.Length;
                var jobtitles = new JobTitle[lenght];
                for (int i = 0; i < lenght; i++)
                {
                    jobtitles[i] = new JobTitle { Id = Guid.NewGuid(), Title = jobTitlesArray[i] };
                }
                context.AddRange(jobtitles);
                context.SaveChanges();
            }
            #endregion

            #region Departments
            if (!context.Departments.Any())
            {
                var lenght = departmentsArray.Length;
                var departments = new Department[lenght];
                for (int i = 0; i < lenght; i++)
                {
                    departments[i] = new Department { Id = Guid.NewGuid(), Title = departmentsArray[i] };
                }
                context.AddRange(departments);
                context.SaveChanges();
            }
            #endregion

            #region Relations
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
            #endregion

        }

        private static Event EventGenerator(Guid id, DateTime startDate)
        {

            int[] days = { 5, 10, 20, 30, 45, 60 };
            var e = new Event
            {
                Id = Guid.NewGuid(),
                From = startDate,
                Till = startDate.AddDays(days[rnd.Next(5)]),
                EmployeeId = id                
            };
            return e;            
        }
    }
}
