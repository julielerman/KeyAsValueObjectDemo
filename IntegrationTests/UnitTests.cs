namespace KeyAsValueObjectDemo.IntegrationTests
{
    [TestClass]
    public class UnitTests
    {
       [TestMethod]
        public void NewContractHasNonEmptyId()
        {
            var contract = new Contract("A New Book");
            Assert.AreNotEqual(Guid.Empty, contract.Id.Value);
        }

    }
}