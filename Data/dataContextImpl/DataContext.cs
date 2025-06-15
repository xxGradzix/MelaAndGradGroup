using Data.API;
using Data.API.Entities;
using Data.Events;
using Data.Users;
using Data.Catalogs;
using Data.States;

namespace Data.dataContextImpl
{
    internal class DataContext : IData
    {
        internal List<Catalog> catalogs { get; } = new List<Catalog>();
        internal List<Event> events { get; } = new List<Event>();
        internal List<User> users { get; } = new List<User>();
        internal List<State> states { get; } = new List<State>();


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
            return catalogs.Cast<ICatalog>().ToList();
        }

        public List<IUser> GetAllUser()
        {
            return users.Cast<IUser>().ToList();
        }

        public List<IEvent> GetAllEvent()
        {
            return events.Cast<IEvent>().ToList();
        }

        public List<IState> GetAllState()
        {
            return states.Cast<IState>().ToList();
        }

        public void AddCatalog(int id, string name, double price, string description)
        {
            Catalog c = new Catalog(id, name, price, description);
            catalogs.Add(c);
        }

        public void AddUser(int id, string username, string password, string email, string phoneNumber)
        {
            User u = new User(id, username, password, email, phoneNumber);
            users.Add(u);
        }


        public void AddEvent(int id, int stateId)
        {
            Event e = new Event(id, GetState(stateId));
            events.Add(e);
        }

        public void AddState(int id, int nrOfProducts, int catalogId)
        {
            State s = new State(states.Count, nrOfProducts, GetCatalog(catalogId));
            states.Add(s);
        }

        public void RemoveCatalog(int catalogId)
        {
            var catalog = GetCatalog(catalogId);
            if (catalog != null)
            {
                catalogs.Remove((Catalog)catalog);
            }
            else
            {
                throw new Exception("No catalog with id: " + catalogId + " found in database.");
            }
        }

        public void RemoveUser(int userId)
        {
            var user = GetUser(userId);
            if (user != null)
            {
                users.Remove((User)user);
            }
            else
            {
                throw new Exception("No user with id: " + userId + " found in database.");
            }
        }

        public void RemoveEvent(int eventId)
        {
            var eventItem = GetEvent(eventId);
            if (eventItem != null)
            {
                events.Remove((Event)eventItem);
            }
            else
            {
                throw new Exception("No event with id: " + eventId + " found in database.");
            }
        }

        public void RemoveState(int stateId)
        {
            var state = GetState(stateId);
            if (state != null)
            {
                states.Remove((State)state);
            }
            else
            {
                throw new Exception("No state with id: " + stateId + " found in database.");
            }
        }

        public void ChangeState(int stateId, int change)
        {
            var state = GetState(stateId);
            if (state != null)
            {
                state.nrOfProducts += change;
            }
            else
            {
                throw new Exception("No state with id: " + stateId + " found in database.");
            }
        }

        public ICatalog? GetCatalog(int id)
        {
            return catalogs.FirstOrDefault(c => c.id == id);
        }

        public IUser? GetUser(int id)
        {
            return users.FirstOrDefault(u => u.id == id);
        }

        public IEvent? GetEvent(int id)
        {
            return events.FirstOrDefault(e => e.eventId == id);
        }

        public IState? GetState(int id)
        {
            return states.FirstOrDefault(s => s.stateId == id);
        }


        public void TruncateData()
        {
            catalogs.Clear();
            events.Clear();
            users.Clear();
            states.Clear();
        }
    }
}