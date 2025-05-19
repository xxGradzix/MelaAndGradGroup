using Data.API.Entities;

namespace Data.API
{
    public interface IData
    {
        IUser? GetUser(Guid id);
        List<IUser> GetUsers();
        void AddUser(IUser user);
        bool DeleteUser(Guid id);

        IProduct? getProduct(Guid id);
        List<IProduct> getProducts();
        void AddProduct(IProduct item);
        bool DeleteProduct(Guid id);

        List<IEvent> GetEvents();
        void AddEvent(IEvent productEvent);
    }
}
