using Data.Events;
using Data.Users;
using Data.Catalogs;
using Data.States;
using Model.Interfaces;
using Logic.Services.Interfaces;

namespace Data.dataContextImpl
{
    internal class DataModel : IDataModel
    {
        private static IDataService _service;
        private string context = "";

        public DataModel()
        {
            _service = IDataService.CreateNewDataService();
        }

        public DataModel(IDataService service)
        {
            _service = service;
        }

        private ICatalogModel Convert(ICatalogService c) => new CatalogModel(c.id, c.name, c.price, c.description);
        private IUserModel Convert(IUserService u) => new UserModel(u.id, u.username, u.password, u.email, u.phoneNumber);
        private IEventModel Convert(IEventService e) => new EventModel(e.id, e.stateId);
        private IStateModel Convert(IStateService s) => new StateModel(s.stateId, s.nrOfProducts, s.catalogId);

        public List<ICatalogModel> GetAllCatalog()
        {
            return _service.GetAllCatalog().Select(Convert).ToList();
        }

        public List<IUserModel> GetAllUser()
        {
            return _service.GetAllUser().Select(Convert).ToList();
        }

        public List<IEventModel> GetAllEvent()
        {
            return _service.GetAllEvent().Select(Convert).ToList();
        }

        public List<IStateModel> GetAllState()
        {
            return _service.GetAllState().Select(Convert).ToList();
        }

        public void AddCatalog(int id, string name, double price, string description)
        {
            if (context == "") return;
            _service.AddCatalog(id, name, price, description);
        }

        public void AddUser(int id, string username, string password, string email, string phoneNumber)
        {
            if (context == "") return;
            _service.AddUser(id, username, password, email, phoneNumber);
        }

        public void AddEvent(int id, int stateId)
        {
            if (context == "") return;
            _service.AddEvent(id, stateId);
        }

        public void AddState(int id, int nrOfProducts, int catalogId)
        {
            if (context == "") return;
            _service.AddState(id, nrOfProducts, catalogId);
        }

        public void RemoveCatalog(int catalogId)
        {
            if (context == "") return;
            _service.RemoveCatalog(catalogId);
        }

        public void RemoveUser(int userId)
        {
            if (context == "") return;
            _service.RemoveUser(userId);
        }

        public void RemoveEvent(int eventId)
        {
            if (context == "") return;
            _service.RemoveEvent(eventId);
        }

        public void RemoveState(int stateId)
        {
            if (context == "") return;
            _service.RemoveState(stateId);
        }

        public ICatalogModel? GetCatalog(int id)
        {
            var catalog = _service.GetCatalog(id);
            return catalog == null ? null : Convert(catalog);
        }

        public IUserModel? GetUser(int id)
        {
            var user = _service.GetUser(id);
            return user == null ? null : Convert(user);
        }

        public IEventModel? GetEvent(int id)
        {
            var ev = _service.GetEvent(id);
            return ev == null ? null : Convert(ev);
        }

        public IStateModel? GetState(int id)
        {
            var state = _service.GetState(id);
            return state == null ? null : Convert(state);
        }

        public void ChangeState(int stateId, int change)
        {
            if (context == "") return;
            _service.ChangeState(stateId, change);
        }

        public void TruncateData()
        {
            if (context == "") return;
            _service.TruncateData();
        }
    }
}