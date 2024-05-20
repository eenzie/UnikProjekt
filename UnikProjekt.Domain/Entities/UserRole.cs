using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Entities;

public class UserRole
{
    internal UserRole()
    {
    }

    internal UserRole(Guid userId, Guid roleId, RoleDates roleDates)
    {
        UserId = userId;
        RoleId = roleId;
        RoleDates = roleDates;
    }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid RoleId { get; set; }
    public Role Role { get; set; }

    public RoleDates RoleDates { get; set; }

    public static UserRole Create(Guid userId, Guid roleId, RoleDates roleDates)
    {
        if (roleDates == null) throw new ArgumentNullException(nameof(roleDates));

        var userRole = new UserRole(userId, roleId, roleDates);

        return userRole;
    }

}
