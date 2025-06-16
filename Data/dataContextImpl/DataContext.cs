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
    internal class DataContext : IData, IDisposable
    {
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

        public List<ICatalog> GetAllCatalog()
        {
            return _context.Products.Cast<ICatalog>().ToList();
        }

        public List<IUser> GetAllUser()
        {
            return _context.Users.Cast<IUser>().ToList();
        }

        public List<IEvent> GetAllEvent()
        {
            return _context.Events.Cast<IEvent>().ToList();
        }

        public List<IState> GetAllState()
        {
            return _context.States.Cast<IState>().ToList();
        }

        public void AddCatalog(int id, string name, double price, string description)
        {
            var existing = _context.Products.FirstOrDefault(c => c.id == id);
            if (existing != null)
            {
                throw new Exception($"Catalog with id {id} already exists.");
            }
            else
            {
                Catalog c = new Catalog(id, name, price, description);
                _context.Products.Add(c);
                _context.SaveChanges();
            }
        }

        public void AddUser(int id, string username, string password, string email, string phoneNumber)
        {
            User u = new User(id, username, password, email, phoneNumber);
            _context.Users.Add(u);
            _context.SaveChanges();
        }


        public void AddEvent(int id, int stateId)
        {
            Event e = new Event(id, (State)GetState(stateId));
            _context.Events.Add(e);
            _context.SaveChanges();
        }

        public void AddState(int id, int nrOfProducts, int catalogId)
        {
            State s = new State(id, nrOfProducts, (Catalog)GetCatalog(catalogId));
            _context.States.Add(s);
            _context.SaveChanges();
        }

        public void RemoveCatalog(int catalogId)
        {
            if (!GetCatalog(catalogId).Equals(null))
            {
                _context.Products.Remove((Catalog)GetCatalog(catalogId));
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No catalog with id: " + catalogId + " found in database.");
            }
        }

        public void RemoveUser(int userId)
        {
            var user = GetUser(userId);
            if (user == null)
            {
                throw new Exception("No user with id: " + userId + " found in database.");
            }
            _context.Users.Remove((User)user);
            _context.SaveChanges();
        }

        public void RemoveEvent(int eventId)
        {
            var eventItem = GetEvent(eventId);
            if (eventItem == null)
            {
                throw new Exception("No event with id: " + eventId + " found in database.");
            }
            _context.Events.Remove((Event)eventItem);
            _context.SaveChanges();
        }

        public void RemoveState(int stateId)
        {
            var state = GetState(stateId);
            if (state == null)
            {
                throw new Exception("No state with id: " + stateId + " found in database.");
            }
            _context.States.Remove((State)state);
            _context.SaveChanges();
        }

        public void ChangeState(int stateId, int change)
        {
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
            _context.Products.RemoveRange(_context.Products);
            _context.Users.RemoveRange(_context.Users);
            _context.Events.RemoveRange(_context.Events);
            _context.States.RemoveRange(_context.States);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            _context = null;
        }

    }
}