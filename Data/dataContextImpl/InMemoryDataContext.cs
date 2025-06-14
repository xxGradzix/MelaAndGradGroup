using Data.API;
using Data.API.Entities;
using Data.Events;
using Data.Users;
using Data.Catalogs;
using Data.States;

namespace Data.dataContextImpl
{
    internal class InMemoryDataContext : IData
    {
        internal List<Catalog> catalogs { get; } = new List<Catalog>();
        internal List<Event> events { get; } = new List<Event>();
        internal List<User> users { get; } = new List<User>();
        internal List<State> states { get; } = new List<State>();

        //public bool DeleteUser(Guid id)
        //{
        //    return users.Remove(id);
        //}


        //public bool DeleteCatalog(Guid id)
        //{
        //    return products.Remove(id);
        //}

        public override void AddCatalog(string name, double price, string description)
        {
            Catalog c = new Catalog(catalogs.Count, name, price, description);
            catalogs.Add(c);
        }
        public override void AddUser(string username, string password, string email, string phoneNumber)
        {
            User u = new User(users.Count, username, password, email, phoneNumber);
            users.Add(u);
        }
        public override void AddState(int nrOfProducts, int catalogId)
        {
            State s = new State(states.Count, nrOfProducts, GetCatalogFromId(catalogId));
            states.Add(s);
        }


        public override void AddUserEvent(int stateId, int userId)
        {
            UserEvent e = new UserEvent(events.Count, GetStateFromId(stateId), GetUserFromId(userId));
            events.Add(e);
        }
        public override void AddDatabaseEvent(int stateId)
        {
            DatabaseEvent e = new DatabaseEvent(events.Count, GetStateFromId(stateId));
            events.Add(e);
        }

        public override void ChangeState(int stateId, int change)
        {
            GetStateFromId(stateId).nrOfProducts += change;
        }

        User GetUserFromId(int id)
        {
            foreach (User users in users)
            {
                if (users.id == id) return users;
            }
            throw new Exception("No user with id: " + id + " found in database.");
        }

        Event GetEventFromId(int id)
        {
            foreach (Event e in events)
            {
                if (e.eventId == id) return e;
            }
            throw new Exception("No event with id: " + id + " found in database.");
        }

        State GetStateFromId(int id)
        {
            foreach (State state in states)
            {
                if (state.stateId == id) return state;
            }
            throw new Exception("No state with id: " + id + " found in database.");
        }

        Catalog GetCatalogFromId(int id)
        {
            foreach (Catalog catalog in catalogs)
            {
                if (catalog.id == id) return catalog;
            }
            throw new Exception("No catalog with id: " + id + " found in database.");
        }
    }
}