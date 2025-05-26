using Data.Repositories;
using Data.Repositories.Interfaces;
using Data.Catalog;
using Data.dataContextImpl.database;
using Microsoft.EntityFrameworkCore;

namespace LogicTest.RepositoriesTest
{
    public class ProductRepositoryTest
    {
        private DbContextOptions<AppDbContext> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        private ProductRepository GetRepo()
        {
            var options = GetInMemoryOptions();
            var context = new AppDbContext(options);
            return new ProductRepository(context);
        }

        private class FakeProduct : Product
        {
            public FakeProduct(string name, double price, int quantity, string description, Guid id)
                : base(name, price, quantity, description)
            {
                this.id = id;
            }
            public FakeProduct()
                : base("Default", 0.0, 0, "Default Description")
            {
                this.id = id;
            }
        }

        [Test]
        public void SaveProduct_ShouldStoreItem()
        {
            ProductRepository repo = GetRepo();
            var item = new FakeProduct { id = Guid.NewGuid(), name = "Example" };

            repo.Save(item);
            var stored = repo.FindByID(item.id);

            Assert.IsNotNull(stored);
            Assert.AreEqual(item.id, stored.id);
        }

        [Test]
        public void GetProduct_NotFound_ReturnsNull()
        {
            IProductRepository repo = GetRepo();
            var result = repo.FindByID(Guid.NewGuid());
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllProducts_ReturnsAllItems()
        {
            IProductRepository repo = GetRepo();
            var item1 = new FakeProduct { id = Guid.NewGuid() };
            var item2 = new FakeProduct { id = Guid.NewGuid() };

            repo.Save(item1);
            repo.Save(item2);

            var result = repo.FindAll();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Exists(i => i.id == item1.id));
            Assert.IsTrue(result.Exists(i => i.id == item2.id));
        }

        [Test]
        public void RemoveProduct_ExistingItem_ReturnsTrue()
        {
            IProductRepository repo = GetRepo();
            var item = new FakeProduct { id = Guid.NewGuid() };
            repo.Save(item);

            var result = repo.Delete(item.id);

            Assert.IsTrue(result);
            Assert.IsFalse(repo.Delete(item.id));
        }

        [Test]
        public void RemoveProduct_NonExisting_ReturnsFalse()
        {
            IProductRepository repo = GetRepo();
            var result = repo.Delete(Guid.NewGuid());

            Assert.IsFalse(result);
        }
    }
}
