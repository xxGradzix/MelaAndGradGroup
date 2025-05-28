using Data.Enums;
using Presentation.Model.API.Enums;

public static class RoleMapper
{
    public static RoleModel ToRoleModel(Role role)
    {
        return role switch
        {
            Role.ADMIN => RoleModel.ADMIN,
            Role.USER => RoleModel.USER,
            _ => throw new ArgumentOutOfRangeException(nameof(role), $"Unknown role: {role}")
        };
    }

    public static Role ToRole(RoleModel model)
    {
        return model switch
        {
            RoleModel.ADMIN => Role.ADMIN,
            RoleModel.USER => Role.USER,
            _ => throw new ArgumentOutOfRangeException(nameof(model), $"Unknown role model: {model}")
        };
    }
}
