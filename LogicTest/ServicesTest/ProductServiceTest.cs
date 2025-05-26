using System.Security.AccessControl;
using Logic.Services;
using Data.Repositories.Interfaces;
using Logic.Services.Interfaces;
using Data.API.Entities;
using Data.Catalog;
using Data.dataContextImpl.database;
using Data.Enums;
using Data.Events;
using Data.Repositories;
using Data.Users;

namespace LogicTest.ServicesTest
{
    public class ProductServiceTest
    {
        private class FakeUser : User
        {
            public FakeUser() : base("username", "email", "password", "phoneNumber", Role.USER)
            {
                this.username = username;
                this.password = password;
                this.email = email;
                this.phoneNumber = phoneNumber;
                this.role = role;
            }

        }

        private class FakeProduct : Product
        {
            public FakeProduct() : base("name", 12345, 1223, "description")
            {
                this.id = id;
                this.name = name;
                this.price = price;
                this.quantity = quantity;
                this.description = description;
            }

        }

        private class FakeEvent : Event
        {
        }

        private class FakeUserRepo : IUserRepository
        {
            private readonly Dictionary<Guid, IUser> users = new();


            public IUser? FindUserByUsername(string username) =>
                users.Values.FirstOrDefault(u => u.username.Equals(username, StringComparison.OrdinalIgnoreCase));

            public User? FindByID(Guid id)
            {
                return users.TryGetValue(id, out var u) ? (User)u : null;
            }

            public User Save(User entity)
            {
                if (users.ContainsKey(entity.id))
                {
                    throw new InvalidOperationException("User already exists");
                }
                users[entity.id] = entity;
                return entity;
            }

            public bool Delete(User entity)
            {
                if (users.ContainsKey(entity.id))
                {
                    users.Remove(entity.id);
                    return true;
                }
                return false;
            }

            public bool Delete(Guid id)
            {
                return users.Remove(id);
            }

            public User Update(User entity)
            {
                if (users.ContainsKey(entity.id))
                {
                    users[entity.id] = entity;
                    return entity;
                }
                throw new InvalidOperationException("User not found");
            }

            public List<User> FindAll()
            {
                return users.Values.Cast<User>().ToList();
            }
        }


        private class FakeProductRepo : IProductRepository
        {
            private readonly Dictionary<Guid, Product> items = new();

            public Product FindByID(Guid id)
            {
                return items.TryGetValue(id, out var item) ? item : null;
            }

            public Product Save(Product entity)
            {
                items[entity.id] = entity;
                return entity;
            }

            public bool Delete(Product entity)
            {
                items.Remove(entity.id);
                return true;
            }

            public bool Delete(Guid id)
            {
                return items.Remove(id);
            }

            public Product Update(Product entity)
            {
                if (items.ContainsKey(entity.id))
                {
                    items[entity.id] = entity;
                    return entity;
                }
                throw new InvalidOperationException("Product not found");
            }

            public List<Product> FindAll()
            {
                return new List<Product>(items.Values);
            }
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

            var fakeUser = new FakeUser { };
            var proId = Guid.NewGuid();
            users.Save(fakeUser);

            
            items.Save(new FakeProduct { id = proId, name = "example", quantity = 1 });

            var result = service.SellProduct(proId, fakeUser.id, 1);

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
            users.Save(new FakeUser {  });

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
            users.Save(new FakeUser { });
            items.Save(new FakeProduct { id = proId, name = "example", quantity = 1 });

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
            Assert.AreEqual(product, repo.FindByID(product.id));
            Assert.AreEqual(1, events.GetAllEvents().Count);
        }

        [Test]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void AddProduct_Duplicate()
        {
            var service = CreateService(out _, out var repo, out _);
            var product = new FakeProduct { id = Guid.NewGuid(), name = "Duplicate", quantity = 1 };
            repo.Save(product);

            //service.AddProduct(product);
            Assert.Throws<InvalidOperationException>(() => service.AddProduct(product));
        }

        [Test]
        public void DeleteProductById_Success()
        {
            var service = CreateService(out _, out var repo, out var events);
            var product = new FakeProduct { id = Guid.NewGuid(), name = "DeleteMe", quantity = 1 };
            repo.Save(product);

            var result = service.DeleteProductById(product.id);

            Assert.IsTrue(result);
            Assert.IsNull(repo.FindByID(product.id));
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
            repo.Save(product);

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
            repo.Save(product1);
            repo.Save(product2);

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
