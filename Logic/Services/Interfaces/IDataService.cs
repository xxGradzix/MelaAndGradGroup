using Data.API;

namespace Logic.Services.Interfaces
{
    public interface IDataService
    {
        public void AddCatalog(int id, string name, double price, string description);
        public void AddUser(int id, string username, string password, string email, string phoneNumber);
        public void AddEvent(int id, int stateId);
        public void AddState(int id, int nrOfBooks, int catalogId);

        public void RemoveCatalog(int id);
        public void RemoveUser(int id);
        public void RemoveEvent(int id);
        public void RemoveState(int id);

        public ICatalogService GetCatalog(int id);
        public IUserService GetUser(int id);
        public IEventService GetEvent(int id);
        public IStateService GetState(int id);

        public List<ICatalogService> GetAllCatalog();
        public List<IUserService> GetAllUser();
        public List<IEventService> GetAllEvent();
        public List<IStateService> GetAllState();

        public void UpdateCatalog(int id, string name, double price, string description);
        public void UpdateUser(int id, string username, string password, string email, string phoneNumber);
        public void UpdateEvent(int id, int stateId);
        public void UpdateState(int id, int nrOfProducts, int catalogId);

        public static IDataService CreateNewDataService()
        {
            return new DataService();
        }

        // public static IDataService CreateNewDataService(string connection)
        // {
        //     IData dataContext = IData.CreateNewContext(connection);
        //     return new DataService(dataContext);
        // }

        public static IDataService CreateNewDataService(IData dataContext)
        {
            return new DataService(dataContext);
        }
    }
}
