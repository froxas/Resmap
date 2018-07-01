using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resmap.Data;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Linq;

namespace Resmap.Tests
{
    [TestClass]
    public class RelationsModelTests
    {
        private DbContextOptions<ApplicationDbContext> _options;

        private readonly ITenantProvider _tenantProvider;
        private readonly IEntityTypeProvider _entityTypeProvider;

        public RelationsModelTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            _tenantProvider = new TenantProvider();
            _entityTypeProvider = new EntityTypeProvider();
            SeedInMemoryStore();
        }

        [TestMethod]
        public void TwoPlusTwoEqualsFour()
        {
            Assert.AreEqual(4, 2 + 2);
        }

        [TestMethod]
        public void RetrieveRelations()
        {
            var context = new ApplicationDbContext(
                _options,
                _tenantProvider,
                _entityTypeProvider
               );

            var _relationService = new RelationService(context);
           var relations = _relationService.GetAllIncludes();
            var i = 0;
            foreach (var item in relations)
            {
                i++;
            }
            Assert.AreEqual(2, i);
        }

        private void SeedInMemoryStore()
        {
            using (var context = new ApplicationDbContext(
                _options,
                _tenantProvider,
                _entityTypeProvider
               ))
            {
                if (!context.Relations.Any())
                {
                    context.Relations.AddRange(
                        new Relation
                        {
                            Id = Guid.NewGuid(),
                            Title = "BCB Group",
                            RelationType = RelationType.Client,
                            RelationId = "1123654"
                        },
                        new Relation
                        {
                            Id = Guid.NewGuid(),
                            Title = "Atene",
                            RelationType = RelationType.Supplier,
                            RelationId = "00012252"
                        }
                        );
                    context.SaveChanges();
                }               
            }
        }
    }
}
