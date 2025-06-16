using Data.API;
using Data.API.Entities;
using Logic.Services.Interfaces;

namespace Logic.Services
{
    internal class DataService : IDataService
        
    {
        static IData _context;

        public DataService()
        {
            _context = IData.CreateNewContext();
        }

        public DataService(IData dataContext)
        {
            _context = dataContext;
        }
        
        private CatalogService CatalogServiceConversion(ICatalog c) => new CatalogService(c.id, c.name, c.price, c.description);
        private UserService UserServiceConversion(IUser c) => new UserService(c.id, c.username, c.password, c.email, c.phoneNumber);
        private EventService EventServiceConversion(IEvent c) => new EventService(c.Id, c.state.Id);
        private StateService StateServiceConversion(IState c) => new StateService(c.Id, c.nrOfProducts, c.catalog.id);

        public void AddCatalog(int id, string name, double price, string description)
        {
            _context.AddCatalog(id, name, price, description);
        }
        public void AddUser(int id, string username, string password, string email, string phoneNumber)
        {
            _context.AddUser(id, username, password, email, phoneNumber);
        }
        public void AddEvent(int id, int stateId)
        {
            _context.AddEvent(id, stateId);
        }

        public void AddState(int id, int nrOfBooks, int catalogId)
        {
            _context.AddState(id, nrOfBooks, catalogId);
        }
        
        
        
        
        public void RemoveCatalog(int id)
        {
            _context.RemoveCatalog(id);
        }
        public void RemoveUser(int id)
        {
            _context.RemoveUser(id);
        }
        public void RemoveEvent(int id)
        {
            _context.RemoveEvent(id);
        }
        public void RemoveState(int id)
        {
            _context.RemoveState(id);
        }
        
        
        
        public ICatalogService GetCatalog(int id)
        {
            return CatalogServiceConversion(_context.GetCatalog(id));
        }
        public IUserService GetUser(int id)
        {
            return UserServiceConversion(_context.GetUser(id));
        }
        public IEventService GetEvent(int id)
        {
            return EventServiceConversion(_context.GetEvent(id));
        }
        public IStateService GetState(int id)
        {
            return StateServiceConversion(_context.GetState(id));
        }
        
        
        
        
        
        public List<ICatalogService> GetAllCatalog()
        {
            List<ICatalogService> catalogList = new List<ICatalogService>();
            foreach (ICatalog c in _context.GetAllCatalog())
            {
                catalogList.Add(CatalogServiceConversion(c));
            }
            return catalogList;
        }
        public List<IUserService> GetAllUser()
        {
            List<IUserService> userList = new List<IUserService>();
            foreach (IUser u in _context.GetAllUser())
            {
                userList.Add(UserServiceConversion(u));
            }
            return userList;
        }
        public List<IEventService> GetAllEvent()
        {
            List<IEventService> eventList = new List<IEventService>();
            foreach (IEvent e in _context.GetAllEvent())
            {
                eventList.Add(EventServiceConversion(e));
            }
            return eventList;
        }
        public List<IStateService> GetAllState()
        {
            List<IStateService> stateList = new List<IStateService>();
            foreach (IState s in _context.GetAllState())
            {
                stateList.Add(StateServiceConversion(s));
            }
            return stateList;
        }
        
        
        
        
        public void UpdateCatalog(int id, string name, double price, string description)
        {
            _context.RemoveCatalog(id);
            _context.AddCatalog(id, name, price, description);
        }
        public void UpdateUser(int id, string username, string password, string email, string phoneNumber)
        {
            _context.RemoveUser(id);
            _context.AddUser(id, username, password, email, phoneNumber);
        }
        public void UpdateEvent(int id, int stateId)
        {
            _context.RemoveEvent(id);
            _context.AddEvent(id, stateId);
        }
        public void UpdateState(int id, int nrOfProducts, int catalogId)
        {
            _context.RemoveState(id);
            _context.AddState(id, nrOfProducts, catalogId);
        }
    }
}
