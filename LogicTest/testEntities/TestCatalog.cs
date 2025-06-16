using Data.API.Entities;
using Data.Catalogs;

namespace LogicTest.testEntities
{
    internal class TestCatalog : Catalog
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
