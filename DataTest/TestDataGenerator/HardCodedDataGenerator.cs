using Data.API;
using Data.API.Entities;
using Data.Catalog;
using Data.dataContextImpl.database;
using Data.Users;

namespace DataTest.TestDataGenerator
{
    internal class HardcodedDataGenerator : IDataGenerator
    {
        private readonly AppDbContext _context;

        public HardcodedDataGenerator(AppDbContext context)
        {
            _context = context;
        }

        public void Generate()
        {
            var product = new Product("name1", 12, 100, "description1");
            _context.Products.Add(product);

            var customer = new Customer("Customer", "customer@mail.com", "password", "123456789");
            _context.Users.Add(customer);

            _context.SaveChanges();
        }
    }
}
