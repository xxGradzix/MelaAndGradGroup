using Logic.Repositories;
using Logic.Repositories.Interfaces;
using Data.API.Entities;

namespace LogicTest.RepositoriesTest
{
    public class ProductRepositoryTest
    {
        private class FakeProduct : IProduct
        {
            public Guid id { get; set; }
            public String name { get; set; } = "";
            public double price { get; set; } = 0.0;
            public int quantity { get; set; } = 0;
            public String description { get; set; } = "";
        }

        [Test]
        public void SaveProduct_ShouldStoreItem()
        {
            IProductRepository repo = new ProductRepository();
            var item = new FakeProduct { id = Guid.NewGuid(), name = "Example" };

            repo.SaveProduct(item);
            var stored = repo.GetProduct(item.id);

            Assert.IsNotNull(stored);
            Assert.AreEqual(item.id, stored!.id);
        }

        [Test]
        public void GetProduct_NotFound_ReturnsNull()
        {
            IProductRepository repo = new ProductRepository();
            var result = repo.GetProduct(Guid.NewGuid());
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllProducts_ReturnsAllItems()
        {
            IProductRepository repo = new ProductRepository();
            var item1 = new FakeProduct { id = Guid.NewGuid() };
            var item2 = new FakeProduct { id = Guid.NewGuid() };

            repo.SaveProduct(item1);
            repo.SaveProduct(item2);

            var result = repo.GetAllProducts();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Exists(i => i.id == item1.id));
            Assert.IsTrue(result.Exists(i => i.id == item2.id));
        }

        [Test]
        public void RemoveProduct_ExistingItem_ReturnsTrue()
        {
            IProductRepository repo = new ProductRepository();
            var item = new FakeProduct { id = Guid.NewGuid() };
            repo.SaveProduct(item);

            var result = repo.RemoveProduct(item.id);

            Assert.IsTrue(result);
            Assert.IsNull(repo.GetProduct(item.id));
        }

        [Test]
        public void RemoveProduct_NonExisting_ReturnsFalse()
        {
            IProductRepository repo = new ProductRepository();
            var result = repo.RemoveProduct(Guid.NewGuid());

            Assert.IsFalse(result);
        }
    }
}
