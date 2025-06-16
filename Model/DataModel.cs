using Data.Events;
using Data.Users;
using Data.Catalogs;
using Data.States;
using Model.Interfaces;

namespace Data.dataContextImpl
{
    internal class DataModel : IDataModel
    {
        internal List<CatalogModel> catalogs { get; } = new List<CatalogModel>();
        internal List<EventModel> events { get; } = new List<EventModel>();
        internal List<UserModel> users { get; } = new List<UserModel>();
        internal List<StateModel> states { get; } = new List<StateModel>();

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
            CatalogModel c = new CatalogModel(catalogs.Count, name, price, description);
            catalogs.Add(c);
        }
        public override void AddUser(string username, string password, string email, string phoneNumber)
        {
            UserModel u = new UserModel(users.Count, username, password, email, phoneNumber);
            users.Add(u);
        }
        public override void AddState(int nrOfProducts, int catalogId)
        {
            StateModel s = new StateModel(states.Count, nrOfProducts, GetCatalogFromId(catalogId));
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

        public override IUserModel GetUserFromId(int id)
        {
            foreach (UserModel users in users)
            {
                if (users.id == id) return users;
            }
            throw new Exception("No user with id: " + id + " found in database.");
        }

        public override IEventModel GetEventFromId(int id)
        {
            foreach (EventModel e in events)
            {
                if (e.eventId == id) return e;
            }
            throw new Exception("No event with id: " + id + " found in database.");
        }

        public override IStateModel GetStateFromId(int id)
        {
            foreach (StateModel state in states)
            {
                if (state.stateId == id) return state;
            }
            throw new Exception("No state with id: " + id + " found in database.");
        }

        public override ICatalogModel GetCatalogFromId(int id)
        {
            foreach (CatalogModel catalog in catalogs)
            {
                if (catalog.id == id) return catalog;
            }
            throw new Exception("No catalog with id: " + id + " found in database.");
        }

        public override List<IUserModel> GetUsers()
        {
            List<IUserModel> userList = new List<IUserModel>();
            foreach (UserModel user in users)
            {
                userList.Add(user);
            }
            return userList;
        }

        public override List<ICatalogModel> getProducts()
        {
            List<ICatalogModel> catalogList = new List<ICatalogModel>();
            foreach (CatalogModel catalog in catalogs)
            {
                catalogList.Add(catalog);
            }
            return catalogList;
        }
    }
}