
using Data.API;
using Data.API.Entities;
using LogicLayerTest;
using LogicTest.testEntities;

namespace LogicTest
{
    internal class TestDataContext: IData
    {
        internal List<ICatalog> catalogs { get; } = new();
        internal List<IEvent> events { get; } = new();
        internal List<IUser> users { get; } = new();
        internal List<IState> states { get; } = new();

        public void AddCatalog(int id, string name, double price, string description)
        {
            TestCatalog c = new TestCatalog(id, name, price, description);
            catalogs.Add(c);
        }

        public void AddUser(int id, string username, string password, string email, string phoneNumber)
        {
            TestUser u = new TestUser(id, username, password, email, phoneNumber);
            users.Add(u);
        }


        public void AddEvent(int eventId, int stateId)
        {
            var state = GetStateFromId(stateId);
            if (state == null)
            {
                throw new ArgumentException($"State with ID {stateId} does not exist.");
            }
            Console.WriteLine($"Adding event with ID {eventId} for state ID {stateId}. and state: {state}");
            TestEvent stateEvent = new TestEvent(eventId, state);
            events.Add(stateEvent);
            // Console.WriteLine($"Event with ID {eventId} added for state ID {stateId}. -------------------------------");
            // Console.WriteLine($"Event count: {events.Count}");
            // Console.WriteLine($"Events: {string.Join(", ", events.Select(e => e.eventId))}");
        }
        public void AddState(int id, int nrOfProducts, int catalogId)
        {
            TestState s = new TestState(id, nrOfProducts, GetCatalogFromId(catalogId));
            states.Add(s);
        }

        public void RemoveCatalog(int id)
        {
            catalogs.Remove(GetCatalogFromId(id));
        }

        public void RemoveUser(int id)
        {
            users.Remove(GetUsersFromId(id));
        }

        public void RemoveEvent(int id)
        {
            events.Remove(GetEventFromId(id));
        }

        public void RemoveState(int id)
        {
            states.Remove(GetStateFromId(id));
        }

        public void ChangeState(int stateId, int change)
        {
            throw new NotImplementedException();
        }

        public ICatalog? GetCatalog(int id)
        {
            return GetCatalogFromId(id);
        }
        public IUser? GetUser(int id)
        {
            return GetUsersFromId(id);
        }
        public IEvent? GetEvent(int id)
        {
            return GetEventFromId(id);
        }
        public IState? GetState(int id)
        {
            return GetStateFromId(id);
        }

        public void TruncateData()
        {
            throw new NotImplementedException();
        }

        public List<ICatalog> GetAllCatalog()
        {
            List<ICatalog> catalogList = new List<ICatalog>();
            foreach (TestCatalog catalog in catalogs)
            {
                if (catalog == null) continue;
                
                catalogList.Add(catalog);
            }
            return catalogList;
        }
        public List<IUser> GetAllUser()
        {
            List<IUser> userList = new List<IUser>();
            foreach (TestUser user in users)
            {
                if (user == null) continue;
                
                userList.Add(user);
            }
            return userList;
        }
        public List<IEvent> GetAllEvent()
        {
            List<IEvent> eventList = new List<IEvent>();
            foreach (TestEvent e in events)
            {
                if (e == null) continue;
                
                eventList.Add(e);
            }
            return eventList;
        }
        public List<IState> GetAllState()
        {
            List<IState> stateList = new List<IState>();
            foreach (TestState state in states)
            {
                if (state == null) continue;
                
                stateList.Add(state);
            }
            return stateList;
        }

        TestUser GetUsersFromId(int id)
        {
            foreach (TestUser users in users)
            {
                if (users.id == id) return users;
            }
            return new TestUser(0, "username", "pass", "email", "phoneNumber");
        }

        TestEvent GetEventFromId(int id)
        {
            foreach (TestEvent e in events)
            {
                if (e.eventId == id) return e;
            }
            return new TestEvent(0, new TestState(0, 1, new TestCatalog(0, "t", 1, "desc")));
        }

        TestState GetStateFromId(int id)
        {
            foreach (TestState state in states)
            {
                if (state.stateId == id) return state;
            }
            return new TestState(0, 1, new TestCatalog(0, "t", 1, "desc"));
        }

        TestCatalog GetCatalogFromId(int id)
        {
            foreach (TestCatalog catalog in catalogs)
            {
                if (catalog.id == id) return catalog;
            }
            return new TestCatalog(0, "t", 1, "desc");
        }
        
        public void CleanData()
        {
            catalogs.Clear();
            users.Clear();
            events.Clear();
            states.Clear();
        }
    }
}
