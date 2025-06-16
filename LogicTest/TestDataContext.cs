
using Data.API;
using Data.API.Entities;
using Data.Catalogs;
using Data.Events;
using Data.States;
using Data.Users;

namespace LogicTest
{
    internal class TestDataContext: IData
    {
        private readonly Dictionary<int, Catalog> catalogs = new();
        private readonly Dictionary<int, User> users = new();
        private readonly Dictionary<int, State> states = new();
        private readonly Dictionary<int, Event> events = new();

        public List<ICatalog> GetAllCatalog() => catalogs.Values.Cast<ICatalog>().ToList();
        public List<IUser> GetAllUser() => users.Values.Cast<IUser>().ToList();
        public List<IEvent> GetAllEvent() => events.Values.Cast<IEvent>().ToList();
        public List<IState> GetAllState() => states.Values.Cast<IState>().ToList();

        public void AddCatalog(int id, string name, double price, string description)
        {
            if (catalogs.ContainsKey(id))
                throw new System.Exception($"Catalog with id {id} already exists.");
            catalogs[id] = new Catalog(id, name, price, description);
        }

        public void AddUser(int id, string username, string password, string email, string phoneNumber)
        {
            if (users.ContainsKey(id))
                throw new System.Exception($"User with id {id} already exists.");
            users[id] = new User(id, username, password, email, phoneNumber);
        }

        public void AddEvent(int id, int stateId)
        {
            if (events.ContainsKey(id))
                throw new System.Exception($"Event with id {id} already exists.");
            if (!states.TryGetValue(stateId, out var state))
                throw new System.Exception($"No state with id: {stateId} found.");
            events[id] = new Event(id, state);
        }

        public void AddState(int id, int nrOfProducts, int catalogId)
        {
            if (states.ContainsKey(id))
                throw new System.Exception($"State with id {id} already exists.");
            if (!catalogs.TryGetValue(catalogId, out var catalog))
                throw new System.Exception($"No catalog with id: {catalogId} found.");
            states[id] = new State(id, nrOfProducts, catalog);
        }

        public void RemoveCatalog(int catalogId)
        {
            if (!catalogs.Remove(catalogId))
                throw new System.Exception($"No catalog with id: {catalogId} found.");
        }

        public void RemoveUser(int userId)
        {
            if (!users.Remove(userId))
                throw new System.Exception($"No user with id: {userId} found.");
        }

        public void RemoveEvent(int eventId)
        {
            if (!events.Remove(eventId))
                throw new System.Exception($"No event with id: {eventId} found.");
        }

        public void RemoveState(int stateId)
        {
            if (!states.Remove(stateId))
                throw new System.Exception($"No state with id: {stateId} found.");
        }

        public void ChangeState(int stateId, int change)
        {
            if (!states.TryGetValue(stateId, out var state))
                throw new System.Exception($"No state with id: {stateId} found.");
            state.nrOfProducts += change;
        }

        public ICatalog? GetCatalog(int id) => catalogs.TryGetValue(id, out var c) ? c : null;
        public IUser? GetUser(int id) => users.TryGetValue(id, out var u) ? u : null;
        public IEvent? GetEvent(int id) => events.TryGetValue(id, out var e) ? e : null;
        public IState? GetState(int id) => states.TryGetValue(id, out var s) ? s : null;

        public void TruncateData()
        {
            catalogs.Clear();
            users.Clear();
            states.Clear();
            events.Clear();
        }
    }
}
