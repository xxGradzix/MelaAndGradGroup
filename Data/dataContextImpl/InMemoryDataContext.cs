using Data.API;
using Data.API.Entities;

namespace Data.dataContextImpl
{
    internal sealed class InMemoryDataContext : IData
    {
        private Dictionary<Guid, IUser> users = new();
        private Dictionary<Guid, IProduct> products = new();
        private List<IEvent> events = new();

        public IUser? GetUser(Guid id)
        {
            return users.GetValueOrDefault(id);
        }

        public List<IUser> GetUsers()
        {
            return users.Values.ToList();
        }

        public void AddUser(IUser user)
        {
            users[user.id] = user;
        }

        public bool DeleteUser(Guid id)
        {
            return users.Remove(id);
        }

        public IProduct? getProduct(Guid id)
        {
            return products.GetValueOrDefault(id);
        }

        public List<IProduct> getProducts()
        {
            return products.Values.ToList();
        }

        public void AddProduct(IProduct item)
        {
            products[item.id] = item;
        }

        public bool DeleteProduct(Guid id)
        {
            return products.Remove(id);
        }

        public List<IEvent> GetEvents()
        {
            return events.ToList();
        }

        public void AddEvent(IEvent productEvent)
        {
            events.Add(productEvent);
        }
    }
}