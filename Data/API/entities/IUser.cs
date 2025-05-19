using Data.Enums;
namespace Data.API.Entities
{
    public interface IUser
    {
        Guid id { get; }
        string username { get; set; }
        string email { get; set; }
        string phoneNumber { get; set; }
        Role role { get; set; }
    }
}
