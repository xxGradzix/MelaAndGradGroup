using Data.API;
using Data.API.Entities;

namespace DataTest
{
    internal static class TestDataGenerator
    {
        internal static void PrepareCatalogData(IData c)
        {
             c.AddCatalog(123, "A", 1, "DESC");
        }

        private class testCatalog : ICatalog
        {
            public int id { get; set; }
            public string name { get; set; }
            public double price { get; set; }
            public string description { get; set; }
            
            public testCatalog(int i, string n, double p, string d)
            {
                id = i;
                name = n;
                price = p;
                description = d;
            }
        }
    }
}
