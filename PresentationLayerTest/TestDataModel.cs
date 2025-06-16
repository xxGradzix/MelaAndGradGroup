using Model.Interfaces;


namespace PresentationLayerTest
    {
        internal class TestDataModel : IDataModel
        {
            public List<TestCatalogModel> Catalogs { get; set; } = new();
            public List<TestUserModel> Users { get; set; } = new();
            public List<TestEventModel> Events { get; set; } = new();
            public List<TestStateModel> States { get; set; } = new();

            public void AddCatalog(int id, string name, double price, string description)
            {
                Catalogs.Add(new TestCatalogModel(id, name, price, description));
            }

            public void AddUser(int id, string username, string password, string email, string phoneNumber)
            {
                Users.Add(new TestUserModel(id, username, password, email, phoneNumber));
            }

            public void AddEvent(int id, int stateId)
            {
                Events.Add(new TestEventModel(id, stateId));
            }

            public void AddState(int id, int nrOfProducts, int catalogId)
            {
                States.Add(new TestStateModel(id, nrOfProducts, catalogId));
            }

            public void RemoveCatalog(int catalogId)
            {
                var item = Catalogs.FirstOrDefault(c => c.id == catalogId);
                if (item != null) Catalogs.Remove(item);
            }

            public void RemoveUser(int userId)
            {
                var item = Users.FirstOrDefault(u => u.id == userId);
                if (item != null) Users.Remove(item);
            }

            public void RemoveEvent(int eventId)
            {
                var item = Events.FirstOrDefault(e => e.eventId == eventId);
                if (item != null) Events.Remove(item);
            }

            public void RemoveState(int stateId)
            {
                var item = States.FirstOrDefault(s => s.stateId == stateId);
                if (item != null) States.Remove(item);
            }

            public ICatalogModel? GetCatalog(int id)
            {
                return Catalogs.FirstOrDefault(c => c.id == id);
            }

            public IUserModel? GetUser(int id)
            {
                return Users.FirstOrDefault(u => u.id == id);
            }

            public IEventModel? GetEvent(int id)
            {
                return Events.FirstOrDefault(e => e.eventId == id);
            }

            public IStateModel? GetState(int id)
            {
                return States.FirstOrDefault(s => s.stateId == id);
            }

            public List<ICatalogModel> GetAllCatalog()
            {
                return Catalogs.Cast<ICatalogModel>().ToList();
            }

            public List<IUserModel> GetAllUser()
            {
                return Users.Cast<IUserModel>().ToList();
            }

            public List<IEventModel> GetAllEvent()
            {
                return Events.Cast<IEventModel>().ToList();
            }

            public List<IStateModel> GetAllState()
            {
                return States.Cast<IStateModel>().ToList();
            }

        int GetCatalogIndexFromId(int id)
        {
            int i = 0;
            foreach (TestCatalogModel t in Catalogs)
            {
                if (t.id == i) return i;
                i++;
            }
            return 0;
        }

        int GetUsersIndexFromId(int id)
        {
            int i = 0;
            foreach (TestUserModel t in Users)
            {
                if (t.id == i) return i;
                i++;
            }
            return 0;
        }

        int GetEventIndexFromId(int id)
        {
            int i = 0;
            foreach (TestEventModel t in Events)
            {
                if (t.eventId == i) return i;
                i++;
            }
            return 0;
        }

        int GetStateIndexFromId(int id)
        {
            int i = 0;
            foreach (TestStateModel t in States)
            {
                if (t.stateId == i) return i;
                i++;
            }
            return 0;
        }
    }
    }

