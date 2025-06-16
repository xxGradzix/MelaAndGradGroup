using Logic.Services.Interfaces;

namespace Model.Interfaces
{
    public interface IDataModel
    {
        public List<ICatalogModel> GetAllCatalog();
        public List<IUserModel> GetAllUser();
        public List<IEventModel> GetAllEvent();
        public List<IStateModel> GetAllState();

        public void AddCatalog(int id, string name, double price, string description);
        public void AddUser(int id, string username, string password, string email, string phoneNumber);
        public void AddEvent(int id, int stateId);
        public void AddState(int id, int nrOfProducts, int catalogId);

        public void RemoveCatalog(int catalogId);
        public void RemoveUser(int userId);
        public void RemoveEvent(int eventId);
        public void RemoveState(int stateId);

        public ICatalogModel? GetCatalog(int id);
        public IUserModel? GetUser(int id);
        public IEventModel? GetEvent(int id);
        public IStateModel? GetState(int id);

        public void ChangeState(int stateId, int change);

        public void TruncateData();


        public static IDataModel CreateNewDataModel()
        {
            return new DataModel();
        }
        public static IDataModel CreateNewDataModel(IDataService service)
        {
            return new DataModel(service);
        }
    }
}
