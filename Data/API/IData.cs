using Data.API.Entities;

namespace Data.API
{
    public abstract class IData
    {
        public abstract void AddCatalog(string name, double price, string description);
        public abstract void AddUser(string username, string password, string email, string phoneNumber);
        public abstract void AddUserEvent(int stateId, int userId);
        public abstract void AddDatabaseEvent(int stateId);
        public abstract void AddState(int nrOfProducts, int catalogId);
        public abstract void ChangeState(int stateId, int change);
    }
}
