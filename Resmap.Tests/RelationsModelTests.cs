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
        //private readonly IEntityTypeProvider _entityTypeProvider;

        public RelationsModelTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            _tenantProvider = new TenantProvider();
          
            
        }

        [TestMethod]
        public void TwoPlusTwoEqualsFour()
        {
            Assert.AreEqual(4, 2 + 2);
        }

        
    }
}
