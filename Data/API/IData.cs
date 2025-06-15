using Data.API.Entities;
using Data.Catalogs;
using Data.dataContextImpl;
using Data.Events;
using Data.States;

namespace Data.API
{
    public interface IData
    {
        
        public List<ICatalog> GetAllCatalog();
        public List<IUser> GetAllUser();
        public List<IEvent> GetAllEvent();
        public List<IState> GetAllState();
        
        public void AddCatalog(int id, string name, double price, string description);
        public void AddUser(int id, string username, string password, string email, string phoneNumber);
        public void AddEvent(int id, int stateId);
        public void AddState(int id, int nrOfProducts, int catalogId);

        public void RemoveCatalog(int catalogId);
        public void RemoveUser(int userId);
        public void RemoveEvent(int eventId);
        public void RemoveState(int stateId);
        
        public void ChangeState(int stateId, int change);
        
        
        public ICatalog? GetCatalog(int id);
        public IUser? GetUser(int id);
        public IEvent? GetEvent(int id);
        public IState? GetState(int id);
        
        public void TruncateData();

        public static IData CreateNewContext()
        {
            return new DataContext();
        }

        // public static IData CreateNewContext(string connectionString)
        // {
        //     return new DataContext(connectionString);
        // }
        
    }
}
