
using IntegrationTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace KeyAsValueObjectDemo.IntegrationTests
{
    [TestClass]
    public class IntegrationTests
    {
        Contract _contract = new Contract("A New Book");
          
        ContractContext _context;

        public IntegrationTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContractContext>();
            optionsBuilder.UseSqlServer(
                 "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=KeyAsValueObjectDemo");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();
            var _options = optionsBuilder.Options;
            _context = new ContractContext(_options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
        [TestMethod]
        public void NewContractHasNonEmptyId()
        {
            _context.Contracts.Add(_contract);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            var contractFromDB = _context.Contracts.FirstOrDefault();
            Assert.AreNotEqual(Guid.Empty, contractFromDB.Id.Value);
        }

        [TestMethod]
        public void NewContractStoresCorrectId()
        {
            var assignedId = _contract.Id;
            _context.Contracts.Add(_contract);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            var contractFromDB = _context.Contracts.FirstOrDefault();
            Assert.AreEqual(assignedId, contractFromDB.Id);
        }

    




        [TestMethod]
        public void NewContractValuesPersistedandRetrieved()
        {
            _context.Contracts.Add(_contract);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            var contractFromDB = _context.Contracts.Include(c => c.Versions).FirstOrDefault();
           //to force the test to fail, you can make the following modification, changing one of the contract instances
            // contractFromDB.FinalVersionSignedByAllParties();
            var expected = JsonSerializer.Serialize(_contract, CustomJsonOptions());
            var actual = JsonSerializer.Serialize(contractFromDB, CustomJsonOptions());
            Assert.AreEqual(expected, actual);
          
        }

        private JsonSerializerOptions CustomJsonOptions()
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            options.Converters.Add(new CustomDateTimeConverter("yyyy-MM-ddTHH:mm:ss"));
             options.Converters.Add(new CustomDecimalConverter("F"));
            return options;

        }

      
    }
}