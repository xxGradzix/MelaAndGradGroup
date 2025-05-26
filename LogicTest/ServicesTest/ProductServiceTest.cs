using System.Security.AccessControl;
using Logic.Services;
using Logic.Repositories.Interfaces;
using Logic.Services.Interfaces;
using Data.API.Entities;
using Data.Enums;

namespace LogicTest.ServicesTest
{
    public class ProductServiceTest
    {
        private class FakeUser : IUser
        {
            public Guid id { get; set; }
            public string username { get; set; } = "";
            public string password { get; set; } = "";
            public string email { get; set; } = "";
            public string phoneNumber { get; set; } = "";
            public Role role { get; set; } = Role.USER;
        }

        private class FakeProduct : IProduct
        {
            public Guid id { get; set; }
            public String name { get; set; } = "";
            public double price { get; set; } = 0.0;
            public int quantity { get; set; } = 0;
            public String description { get; set; } = "";
        }

        private class FakeEvent : IEvent
        {
            public Guid eventId { get; } = Guid.NewGuid();
            public DateTime timestamp { get; set; } = DateTime.Now;
        }

        private class FakeUserRepo : IUserRepository
        {
            private readonly Dictionary<Guid, IUser> users = new();

            public void AddUser(IUser user) => users[user.id] = user;

            public IUser? GetUser(Guid id)
            {
                return users.TryGetValue(id, out var u) ? u : null;
            }

            public List<IUser> GetAllUsers() => new(users.Values);

            public bool RemoveUser(Guid id) => users.Remove(id);

            public IUser? FindUserByUsername(string username) =>
                users.Values.FirstOrDefault(u => u.username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }


        private class FakeProductRepo : IProductRepository
        {
            private readonly Dictionary<Guid, IProduct> items = new();

            public void SaveProduct(IProduct content) => items[content.id] = content;

            public bool RemoveProduct(Guid id) => items.Remove(id);

            public IProduct? GetProduct(Guid id) => items.TryGetValue(id, out var item) ? item : null;

            public List<IProduct> GetAllProducts() => new(items.Values);
        }


        private class FakeEventService : IEventService
        {
            private readonly List<IEvent> events = new();

            public bool AddEvent(IEvent eventBase)
            {
                events.Add(eventBase);
                return true;
            }

            public List<IEvent> GetAllEvents() => new(events);

            public List<IEvent> Events => events;
        }

        private class FakeEventFactory : IEventFactory
        {
            public IEvent CreateUserAddedEvent(Guid userId, string userEmail) => new FakeEvent();
            public IEvent CreateNewUserAddedEvent(Guid userId, string userEmail) => new FakeEvent();
            public IEvent CreateUserRemovedEvent(Guid userId) => new FakeEvent();

            public IEvent CreateProductBoughtEvent(Guid userId, Guid productId, int quantity) => new FakeEvent();
            public IEvent CreateProductAddedEvent(Guid productId, int quantity) => new FakeEvent();
            public IEvent CreateProductRemovedEvent(Guid productId) => new FakeEvent();
            public IEvent CreateSellProductEvent(Guid userId, Guid itemId, int quantity) => new FakeEvent();
        }

        private ProductService CreateService(out FakeUserRepo userRepo, out FakeProductRepo productRepo, out FakeEventService eventService)
        {
            userRepo = new FakeUserRepo();
            productRepo = new FakeProductRepo();
            eventService = new FakeEventService();

            return new ProductService(userRepo, productRepo, eventService, new FakeEventFactory());
        }

        [Test]
        public void SellProduct_Success()
        {
            var service = CreateService(out var users, out var items, out var events);
            var userId = Guid.NewGuid();
            var proId = Guid.NewGuid();
            users.AddUser(new FakeUser { id = userId });

            
            items.SaveProduct(new FakeProduct { id = proId, name = "example", quantity = 1 });

            var result = service.SellProduct(proId, userId, 1);

             Console.WriteLine(result);
            
             Assert.IsNotNull(result);
            Assert.AreEqual(proId, result.id);
            Assert.AreEqual(0, result.quantity);
            Assert.AreEqual(1, events.Events.Count);
        }
        

        [Test]
        public void SellProduct_UserNotFound()
        {
            var service = CreateService(out _, out var items, out _);
            var userId = Guid.NewGuid();
            var proId = Guid.NewGuid();
            service.AddProduct(new FakeProduct { id = proId, name = "example", quantity = 1 });

            Assert.Throws<InvalidOperationException>(() => service.SellProduct(userId, proId, 1));
        }

        [Test]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void SellProduct_ItemNotFound()
        {
            var service = CreateService(out var users, out _, out _);
            var userId = Guid.NewGuid();
            var itemId = Guid.NewGuid();
            users.AddUser(new FakeUser { id = userId });

            //service.SellProduct(userId, itemId, 1);
            Assert.Throws<InvalidOperationException>(() => service.SellProduct(userId, itemId, 1));
        }

        [Test]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void SellProduct_NotEnoughtProducts()
        {
            var service = CreateService(out var users, out var items, out _);
            var userId = Guid.NewGuid();
            var proId = Guid.NewGuid();
            users.AddUser(new FakeUser { id = userId });
            items.SaveProduct(new FakeProduct { id = proId, name = "example", quantity = 1 });

            //service.SellProduct(userId, proId, 2);
            Assert.Throws<InvalidOperationException>(() => service.SellProduct(userId, proId, 2));
        }

        [Test]
        public void AddProduct_Success()
        {
            var service = CreateService(out _, out var repo, out var events);
            var product = new FakeProduct { id = Guid.NewGuid(), name = "Test", quantity = 10 };

            var result = service.AddProduct(product);

            Assert.AreEqual(product, result);
            Assert.AreEqual(product, repo.GetProduct(product.id));
            Assert.AreEqual(1, events.GetAllEvents().Count);
        }

        [Test]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void AddProduct_Duplicate()
        {
            var service = CreateService(out _, out var repo, out _);
            var product = new FakeProduct { id = Guid.NewGuid(), name = "Duplicate", quantity = 1 };
            repo.SaveProduct(product);

            //service.AddProduct(product);
            Assert.Throws<InvalidOperationException>(() => service.AddProduct(product));
        }

        [Test]
        public void DeleteProductById_Success()
        {
            var service = CreateService(out _, out var repo, out var events);
            var product = new FakeProduct { id = Guid.NewGuid(), name = "DeleteMe", quantity = 1 };
            repo.SaveProduct(product);

            var result = service.DeleteProductById(product.id);

            Assert.IsTrue(result);
            Assert.IsNull(repo.GetProduct(product.id));
            Assert.AreEqual(1, events.GetAllEvents().Count);
        }

        [Test]
        public void DeleteProductById_ProductNotFound_ReturnsFalse()
        {
            var service = CreateService(out _, out _, out var events);
            var result = service.DeleteProductById(Guid.NewGuid());

            Assert.IsFalse(result);
            Assert.AreEqual(0, events.GetAllEvents().Count);
        }

        [Test]
        public void FindById_Success()
        {
            var service = CreateService(out _, out var repo, out _);
            var product = new FakeProduct { id = Guid.NewGuid(), name = "FindMe", quantity = 1 };
            repo.SaveProduct(product);

            var result = service.FindById(product.id);

            Assert.AreEqual(product, result);
        }

        [Test]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void FindById_ProductNotFound()
        {
            var service = CreateService(out _, out _, out _);
            //service.FindById(Guid.NewGuid());
            Assert.Throws<InvalidOperationException>(() => service.FindById(Guid.NewGuid()));
        }

        [Test]
        public void FindAll_ProductsExist_ReturnsList()
        {
            var service = CreateService(out _, out var repo, out _);
            var product1 = new FakeProduct { id = Guid.NewGuid(), name = "example1", quantity = 2 };
            var product2 = new FakeProduct { id = Guid.NewGuid(), name = "example2", quantity = 3 };
            repo.SaveProduct(product1);
            repo.SaveProduct(product2);

            var products = service.FindAll();

            Assert.AreEqual(2, products.Count);
            CollectionAssert.Contains(products, product1);
            CollectionAssert.Contains(products, product2);
        }

        [Test]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void FindAll_EmptyList()
        {
            var service = CreateService(out _, out _, out _);
            //service.FindAll();
            Assert.Throws<InvalidOperationException>(() => service.FindAll());
        }
    }
}
