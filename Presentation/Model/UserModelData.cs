using System;
using Presentation.Model.API;
using Presentation.Model.API.Enums;

namespace Presentation.Model
{
    internal class UserModelData : IUserModelData
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public RoleModel role { get; set; }

        public UserModelData(Guid id, string username, string password, string email, string phoneNumber, RoleModel role)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.role = role;
        }
    }
}