using Data.API.Entities;

namespace LogicTest.testEntities
{
    internal class TestCatalog : ICatalog
    {
        public TestCatalog(int catalogId, string name, double price, string description)
        {
            this.id = catalogId;
            this.name = name;
            this.price = price;
            this.description = description;
        }
    }
}
