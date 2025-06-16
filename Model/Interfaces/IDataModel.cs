using Data.Catalogs;
using Data.dataContextImpl;
using Data.Events;
using Data.States;
using Logic.Services.Interfaces;

namespace Model.Interfaces
{
    public interface IDataModel
    {
        public abstract void AddCatalog(string name, double price, string description);
        public abstract void AddUser(string username, string password, string email, string phoneNumber);
        public abstract void AddUserEvent(int stateId, int userId);
        public abstract void AddDatabaseEvent(int stateId);
        public abstract void AddState(int nrOfProducts, int catalogId);
        public abstract void ChangeState(int stateId, int change);
        
        public abstract IUserModel GetUserFromId(int id);
        public abstract IEventModel GetEventFromId(int id);
        public abstract IStateModel GetStateFromId(int id);
        public abstract ICatalogModel GetCatalogFromId(int id);
        public abstract List<IUserModel> GetUsers();
        public abstract List<ICatalogModel> getProducts();

        public static IDataModel CreateNewDataModel()
        {
            return new DataModel();
        }
        public static IDataModel CreateNewDataModel(IDataService s)
        {
            return new DataModel(s);
        }
    }
}
