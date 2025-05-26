using Data.dataContextImpl.database;
using DataTest.TestDataGeneration;
using DataTest.TestDataGenerator;
using Microsoft.EntityFrameworkCore;


namespace DataTest.Tests
{
    public class RandomDataTest
    {
        private AppDbContext _context;

        [SetUp]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _context = new AppDbContext(options);

            var generator = new RandomDataGenerator(_context);
            generator.Generate();
        }
        
        [TearDown]
        public void Cleanup()
        {
            _context?.Dispose();
        }

        [Test]
        public void TestGeneratedProducts()
        {
            Assert.IsTrue(_context.Products.Count() > 0, "No products generated");
        }

        [Test]
        public void TestGeneratedUsers()
        {
            Assert.IsTrue(_context.Users.Count() > 0, "No users generated");
        }
    }
}
