using Data.API.Entities;
using Data.Catalogs;
using Data.Events;
using Data.States;

namespace Data.API
{
    public abstract class IData
    {
        public abstract void AddCatalog(string name, double price, string description);
        public abstract void AddUser(string username, string password, string email, string phoneNumber);
        public abstract void AddUserEvent(int stateId, int userId);
        public abstract void AddDatabaseEvent(int stateId);
        public abstract void AddState(int nrOfProducts, int catalogId);
        public abstract void ChangeState(int stateId, int change);
        
        public abstract IUser GetUserFromId(int id);
        public abstract IEvent GetEventFromId(int id);
        public abstract IState GetStateFromId(int id);
        public abstract ICatalog GetCatalogFromId(int id);
        public abstract List<IUser> GetUsers();
        public abstract List<ICatalog> getProducts();
    }
}
