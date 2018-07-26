using RandomNameGeneratorLibrary;
using Resmap.Domain;
using System;
using System.Linq;

namespace Resmap.Data
{
    public static class DbInitializer
    {
        static Random rnd = new Random();

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            string[] departmentsArray = new string[] { "Design", "Development", "Offshore", "Sales" };
            string[] jobTitlesArray = new string[] { "Developer", "Architect", "Manager", "Designer" };
            Employee[] employees = new Employee[65];            
            DateTime startDate = DateTime.UtcNow.AddDays(-60);

            #region Departments
            
            Department[] departments = new Department[departmentsArray.Length];
            Guid[] departmentsIds = new Guid[departmentsArray.Length];
            for (int i = 0; i < departments.Length; i++)
            {
                departments[i] = new Department
                {
                    Id = Guid.NewGuid(),
                    Title = departmentsArray[i]
                };
                departmentsIds[i] = departments[i].Id;
            }
            context.AddRange(departments);
            context.SaveChanges();

            #endregion

            #region JobTitle
            JobTitle[] jobTitles = new JobTitle[jobTitlesArray.Length];
            Guid[] jobTitlesIds = new Guid[jobTitlesArray.Length];
            for (int i = 0; i < jobTitles.Length; i++)
            {
                jobTitles[i] = new JobTitle
                {
                    Id = Guid.NewGuid(),
                    Title = jobTitlesArray[i]
                };
                jobTitlesIds[i] = jobTitles[i].Id;
            }
            context.AddRange(jobTitles);
            context.SaveChanges();
            #endregion

            #region Relations
            if (!context.Relations.Any())
            {
                Relation[] relations = new Relation[15];
                for (int i = 0; i < relations.Length; i++)
                {
                    relations[i] = new Relation
                    {
                        Id = Guid.NewGuid(),
                        RelationId = rnd.Next(1, 99999).ToString(),
                        Title = Faker.Company.Name(),
                        Address = new Address
                        {
                            Id = Guid.NewGuid(),
                            Street = Faker.Address.StreetName(),
                            House = rnd.Next(199).ToString(),
                            City = Faker.Address.City(),
                            Country = Faker.Address.Country(),
                            PostCode = Faker.Address.ZipCode()
                        },
                        Contact = new Contact
                        {
                            Id = Guid.NewGuid(),
                            ContactPerson = Faker.Name.FullName(),
                            PhoneNumber = Faker.Phone.Number(),
                            Email = Faker.Internet.Email()
                        },
                        Note = new Note
                        {
                            Id = Guid.NewGuid(),
                            Title = Faker.Lorem.Sentence(2)
                        }
                    };
                }
                context.AddRange(relations);
                context.SaveChanges();
            }
            #endregion

            #region Employees            
            if (!context.Employees.Any())
            {
                var personGenerator = new PersonNameGenerator();

                var relation = context.Relations.Where(x => x.RelationType==RelationType.Subcontractor).FirstOrDefault();
                for (int i = 0; i < employees.Length; i++)
                {
                    employees[i] = new Employee
                    {
                        Id = Guid.NewGuid(),
                        EmployeeID = rnd.Next(1, 9999).ToString(),
                        FirstName = personGenerator.GenerateRandomFirstName(),
                        LastName = personGenerator.GenerateRandomLastName(),
                        DepartmentId = departmentsIds[rnd.Next(4)],
                        JobTitleId = jobTitlesIds[rnd.Next(4)],
                        IsSubcontractor = false,
                        //Subcontractor = relation,
                        Address = new Address
                        {
                            Id = Guid.NewGuid(),
                            Street = Faker.Address.StreetName(),
                            House = rnd.Next(199).ToString(),
                            Flat = rnd.Next(30).ToString(),
                            City = Faker.Address.City(),
                            Country = Faker.Address.Country(),
                            PostCode = Faker.Address.ZipCode()
                        },
                        Contact = new Contact
                        {
                            Id = Guid.NewGuid(),
                            //ContactPerson = Faker.Name.FullName(),
                            PhoneNumber = Faker.Phone.Number(),
                            Email = Faker.Internet.Email()
                        },
                    };
                }
                context.AddRange(employees);
                context.SaveChanges();
            }
            #endregion
            
            #region Cars
            if (!context.Cars.Any())
            {
                Car[] cars = new Car[] {
                    new Car { Id=Guid.NewGuid(), NumberPlate="HHA015", Model="Opel Astra"},
                    new Car { Id=Guid.NewGuid(), NumberPlate="HHA012", Model="Kia Ceed"},
                    new Car { Id=Guid.NewGuid(), NumberPlate="OHB114", Model="VW Gold"},
                    new Car { Id=Guid.NewGuid(), NumberPlate="AHN336", Model="Opel Vectra"}
                };
                context.AddRange(cars);
                context.SaveChanges();
            }

            #endregion

            #region Tags
            if (!context.Tags.Any())
            {
                Tag[] tags = new Tag[] {
                    new Tag { Id=Guid.NewGuid(), Title="Java", Level=TagLevel.Level1, TagType=TagType.Employee},
                    new Tag { Id=Guid.NewGuid(), Title="C#", Level=TagLevel.Level1, TagType=TagType.Employee},
                    new Tag { Id=Guid.NewGuid(), Title="English", Level=TagLevel.Level2, TagType=TagType.Employee},
                    new Tag { Id=Guid.NewGuid(), Title="Design", Level=TagLevel.Level3, TagType=TagType.Employee},
                    new Tag { Id=Guid.NewGuid(), Title="Web", Level=TagLevel.Level1, TagType=TagType.Project},
                    new Tag { Id=Guid.NewGuid(), Title="Mobile", Level=TagLevel.Level1, TagType=TagType.Project},
                    new Tag { Id=Guid.NewGuid(), Title="India", Level=TagLevel.Level2, TagType=TagType.Project}
                };
                context.AddRange(tags);
                context.SaveChanges();
            }

            #endregion

            /*
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
            */
                                    
            #region Projects
            if (!context.Projects.Any())
            {
                var client = context.Relations.FirstOrDefault();
                Project[] project = new Project[] {
                    new Project { Id=Guid.NewGuid(), Title="GoBiGas", Manager="Petras Kaufmanas", Client = client },
                    new Project { Id=Guid.NewGuid(), Title="Piping installation", Manager="Andris Parnu", Client = client },
                    new Project { Id=Guid.NewGuid(), Title="Insulation Tanks", Manager="Jeronimas Milius", Client = client },
                };
                context.AddRange(project);
                context.SaveChanges();

            }
            #endregion

            #region Events
            if (!context.EmployeeEvents.Any())
            {
                var employee = context.Employees.FirstOrDefault();
                var project = context.Projects.FirstOrDefault();

                EmployeeEvent[] employeeEvents = new EmployeeEvent[]
                {
                    new EmployeeEvent
                    {
                        Id = Guid.NewGuid(),
                        Start = DateTime.UtcNow.AddDays(-10),
                        End = DateTime.UtcNow.AddDays(15),
                        Resource = employee.Id,
                        Project = project

                    },
                     new EmployeeEvent
                    {
                        Id = Guid.NewGuid(),
                        Start = DateTime.UtcNow.AddDays(25),
                        End = DateTime.UtcNow.AddDays(120),
                        Resource = employee.Id,
                        Project = project
                    }
                };

                context.AddRange(employeeEvents);
                context.SaveChanges();
            }

            if (!context.CarEvents.Any())
            {
                var employee = context.Employees.FirstOrDefault();
                var car = context.Cars.FirstOrDefault();

                CarEvent[] carEvents = new CarEvent[]
                {
                    new CarEvent
                    {
                        Id = Guid.NewGuid(),
                        Start = DateTime.UtcNow.AddDays(-10),
                        End = DateTime.UtcNow.AddDays(15),
                        Resource = car.Id,
                        Employee = employee
                    },
                     new CarEvent
                    {
                        Id = Guid.NewGuid(),
                        Start = DateTime.UtcNow.AddDays(25),
                        End = DateTime.UtcNow.AddDays(120),
                        Resource = car.Id,
                        Employee = employee
                    }
                };

                context.AddRange(carEvents);
                context.SaveChanges();
            }
            #endregion

        }

        /*
        private static Event EventGenerator(Guid id, DateTime startDate)
        {

            int[] days = { 5, 10, 20, 30, 45, 60 };
            var e = new Event
            {
                TenantId = Guid.Parse("4d0b6b71-549f-47aa-b692-744f478e5e45"),
                Id = Guid.NewGuid(),
                From = startDate,
                Till = startDate.AddDays(days[rnd.Next(5)]),
                //EmployeeId = id                
            };
            return e;            
        }
        */

    }
}
