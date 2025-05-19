namespace Data.API.Entities
{
    public interface IUserFactory
    {
        IUser CreateUser(string name, string surname, string email, string phoneNumber);
    }
}