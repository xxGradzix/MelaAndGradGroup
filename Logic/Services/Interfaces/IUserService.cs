using Data.API.Entities;

namespace Logic.Services.Interfaces
{
    public interface IUserService
    {
        IUser Register(string username, string password, string email, string phonenumber);
        bool Login(string username, string password);
        bool Remove(Guid id);
        IUser GetById(Guid id);
        List<IUser> FindAll();
    }

}
