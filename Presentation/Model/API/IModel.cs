using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IModel
    {
        // Produkty
        List<IProductModelData> GetAllProducts();
        IProductModelData? GetProductById(Guid id);
        void AddProduct(string name, double price, int quantity, string description);
        bool DeleteProduct(Guid id);
        void SellProduct(Guid productId, Guid userId, int quantity);

        // Użytkownicy
        void RegisterUser(string username, string password, string email, string phoneNumber);
        bool Login(string username, string password);
        bool RemoveUser(Guid id);
        IUserModelData? GetUserById(Guid id);
        List<IUserModelData> GetAllUsers();

        // Eventy
        void AddEvent(Guid id, DateTime timestamp);
        List<IEventModelData> GetAllEvents();
    }
}