using Data.API;
using Data.API.Entities;
using Data.Events;
using Data.Users;
using Data.Catalogs;
using Data.dataContextImpl.database;
using Data.States;
using Microsoft.EntityFrameworkCore;

namespace Data.dataContextImpl
{
    internal class DataContext : IData
    {
        // internal Dictionary<int, Catalog> catalogs { get; } = new Dictionary<int, Catalog>();
        // internal List<Event> events { get; } = new List<Event>();
        // internal List<User> users { get; } = new List<User>();
        // internal List<State> states { get; } = new List<State>();


        private AppDbContext _context;
        
        private DbContextOptions<AppDbContext> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }
        
        public DataContext(string? customConnectionString = null)
        {
            if (customConnectionString != null)
            {
                _context = new AppDbContext(GetInMemoryOptions());
            }
            else
            {
                _context = new AppDbContext(GetInMemoryOptions());
            }
        }
        // public void AddCatalog(int id, string name, double price, string description)
        // {
        //     // Catalog c = new Catalog(catalogs.Count, name, price, description);
        //     Catalog c = new Catalog(id, name, price, description);
        //     catalogs.Add(c);
        // }
        // public void AddUser(int id, string username, string password, string email, string phoneNumber)
        // {
        //     // User u = new User(users.Count, username, password, email, phoneNumber);
        //     User u = new User(id, username, password, email, phoneNumber);
        //     users.Add(u);
        // }
        //
        // public void AddState(int id, int nrOfProducts, int catalogId)
        // {
        //     State s = new State(states.Count, nrOfProducts, GetCatalogFromId(catalogId));
        //     states.Add(s);
        // }
        //
        //
        // public void AddUserEvent(int id, int stateId, int userId)
        // {
        //     // UserEvent e = new UserEvent(events.Count, GetStateFromId(stateId), GetUserFromId(userId));
        //     UserEvent e = new UserEvent(id, GetStateFromId(stateId), GetUserFromId(userId));
        //     events.Add(e);
        // }
        // public void AddDatabaseEvent(int id, int stateId)
        // {
        //     // DatabaseEvent e = new DatabaseEvent(events.Count, GetStateFromId(stateId));
        //     DatabaseEvent e = new DatabaseEvent(id, GetStateFromId(stateId));
        //     events.Add(e);
        // }
        //
        // public void ChangeState(int stateId, int change)
        // {
        //     GetStateFromId(stateId).nrOfProducts += change;
        // }
        //
        // public IUser? GetUser(int id)
        // {
        //     var entity = (from User
        //             in c.Users
        //         where User.userId == id
        //         select User).FirstOrDefault();
        //     if (entity == null)
        //     {
        //         return null;
        //     }
        //     else
        //     {
        //         return new LibraryUser(entity.userId, entity.firstName, entity.lastName);
        //     }
        // }
        //
        // public override IEvent GetEventFromId(int id)
        // {
        //     foreach (Event e in events)
        //     {
        //         if (e.eventId == id) return e;
        //     }
        //     throw new Exception("No event with id: " + id + " found in database.");
        // }
        //
        // public override IState GetStateFromId(int id)
        // {
        //     foreach (State state in states)
        //     {
        //         if (state.stateId == id) return state;
        //     }
        //     throw new Exception("No state with id: " + id + " found in database.");
        // }
        //
        // public override ICatalog GetCatalogFromId(int id)
        // {
        //     foreach (Catalog catalog in catalogs)
        //     {
        //         if (catalog.id == id) return catalog;
        //     }
        //     throw new Exception("No catalog with id: " + id + " found in database.");
        // }
        //
        // public override List<IUser> GetUsers()
        // {
        //     List<IUser> userList = new List<IUser>();
        //     foreach (User user in users)
        //     {
        //         userList.Add(user);
        //     }
        //     return userList;
        // }
        //
        // public override List<ICatalog> getProducts()
        // {
        //     List<ICatalog> catalogList = new List<ICatalog>();
        //     foreach (Catalog catalog in catalogs)
        //     {
        //         catalogList.Add(catalog);
        //     }
        //     return catalogList;
        // }
        public List<ICatalog> GetAllCatalog()
        {
            // return catalogs.Values.Cast<ICatalog>().ToList();
            return _context.Products.Cast<ICatalog>().ToList();
        }

        public List<IUser> GetAllUser()
        {
            // return users.Cast<IUser>().ToList();
            return _context.Users.Cast<IUser>().ToList();
        }

        public List<IEvent> GetAllEvent()
        {
            // return events.Cast<IEvent>().ToList();
            return _context.Events.Cast<IEvent>().ToList();
        }

        public List<IState> GetAllState()
        {
            // return states.Cast<IState>().ToList();
            return _context.States.Cast<IState>().ToList();
        }

        public void AddCatalog(int id, string name, double price, string description)
        {
            // if (!catalogs.ContainsKey(id))
            // {
            //     Catalog c = new Catalog(id, name, price, description);
            //     catalogs.Add(id, c);
            // }
            // else
            // {
            //     throw new Exception($"Catalog with id {id} already exists.");
            // }
            
            Catalog c = new Catalog(id, name, price, description);
            // catalogs.Add(id, c);
            _context.Products.Add(c);
            _context.SaveChanges();
        }

        public void AddUser(int id, string username, string password, string email, string phoneNumber)
        {
            User u = new User(id, username, password, email, phoneNumber);
            // users.Add(u);
            _context.Users.Add(u);
            _context.SaveChanges();
        }


        public void AddEvent(int id, int stateId)
        {
            Event e = new Event(id, (State)GetState(stateId));
            // events.Add(e);
            _context.Events.Add(e);
            _context.SaveChanges();
        }

        public void AddState(int id, int nrOfProducts, int catalogId)
        {
            State s = new State(id, nrOfProducts, (Catalog)GetCatalog(catalogId));
            // states.Add(s);
            _context.States.Add(s);
            _context.SaveChanges();
        }

        public void RemoveCatalog(int catalogId)
        {
            // if (catalogs.ContainsKey(catalogId))
            // {
            //     catalogs.Remove(catalogId);
            // }
            // else
            // {
            //     throw new Exception("No catalog with id: " + catalogId + " found in database.");
            // }
            if (!GetCatalog(catalogId).Equals(null))
            {
                _context.Products.Remove((Catalog)GetCatalog(catalogId));
                _context.SaveChanges();
                // catalogs.Remove(catalogId);
            }
            else
            {
                throw new Exception("No catalog with id: " + catalogId + " found in database.");
            }
        }

        public void RemoveUser(int userId)
        {
            // var user = GetUser(userId);
            // if (user != null)
            // {
            //     users.Remove((User)user);
            // }
            // else
            // {
            //     throw new Exception("No user with id: " + userId + " found in database.");
            // }
            var user = GetUser(userId);
            if (user == null)
            {
                throw new Exception("No user with id: " + userId + " found in database.");
            }
            // users.Remove((User)user);
            _context.Users.Remove((User)user);
            _context.SaveChanges();
        }

        public void RemoveEvent(int eventId)
        {
            // var eventItem = GetEvent(eventId);
            // if (eventItem != null)
            // {
            //     events.Remove((Event)eventItem);
            // }
            // else
            // {
            //     throw new Exception("No event with id: " + eventId + " found in database.");
            // }
            var eventItem = GetEvent(eventId);
            if (eventItem == null)
            {
                throw new Exception("No event with id: " + eventId + " found in database.");
            }
            // events.Remove((Event)eventItem);
            _context.Events.Remove((Event)eventItem);
            _context.SaveChanges();
        }

        public void RemoveState(int stateId)
        {
            // var state = GetState(stateId);
            // if (state != null)
            // {
            //     states.Remove((State)state);
            // }
            // else
            // {
            //     throw new Exception("No state with id: " + stateId + " found in database.");
            // }
            var state = GetState(stateId);
            if (state == null)
            {
                throw new Exception("No state with id: " + stateId + " found in database.");
            }
            // states.Remove((State)state);
            _context.States.Remove((State)state);
            _context.SaveChanges();
        }

        public void ChangeState(int stateId, int change)
        {
            // var state = GetState(stateId);
            // if (state != null)
            // {
            //     state.nrOfProducts += change;
            // }
            // else
            // {
            //     throw new Exception("No state with id: " + stateId + " found in database.");
            // }
            var state = GetState(stateId);
            if (state == null)
            {
                throw new Exception("No state with id: " + stateId + " found in database.");
            }
            state.nrOfProducts += change;
            _context.States.Update((State)state);
            _context.SaveChanges();
            
        }

        public ICatalog? GetCatalog(int id)
        {
            // if (catalogs.TryGetValue(id, out var catalog))
            // {
                // return catalog;
            // }
            // return null;
            var entity = _context.Products.FirstOrDefault(c => c.id == id);
            if (entity == null)
            {
                return null;
            }
            else
            {
                return entity;
            }
            
        }

        public IUser? GetUser(int id)
        {
            // return users.FirstOrDefault(u => u.id == id);
            var entity = _context.Users.FirstOrDefault(u => u.id == id);
            if (entity == null)
            {
                return null;
            }
            else
            {
                return entity;
            }
        }

        public IEvent? GetEvent(int id)
        {
            // return events.FirstOrDefault(e => e.eventId == id);
            var entity = _context.Events.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                return null;
            }
            else
            {
                return entity;
            }
        }

        public IState? GetState(int id)
        {
            // return states.FirstOrDefault(s => s.stateId == id);
            var entity = _context.States.FirstOrDefault(s => s.Id == id);
            if (entity == null)
            {
                return null;
            }
            else
            {
                return entity;
            }
        }


        public void TruncateData()
        {
            // catalogs.Clear();
            // events.Clear();
            // users.Clear();
            // states.Clear();
            _context.Products.RemoveRange(_context.Products);
            _context.Users.RemoveRange(_context.Users);
            _context.Events.RemoveRange(_context.Events);
            _context.States.RemoveRange(_context.States);
            _context.SaveChanges();
        }
    }
}