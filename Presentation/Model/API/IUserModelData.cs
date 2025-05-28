using Presentation.Model.API.Enums;

namespace Presentation.Model.API
{
    public interface IUserModelData
    {
        Guid id { get; }
        string username { get; set; }
        string password { get; set; }
        string email { get; set; }
        string phoneNumber { get; set; }
        RoleModel role { get; set; }
    }
}