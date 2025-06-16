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

        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}
