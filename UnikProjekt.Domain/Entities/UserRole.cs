﻿using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Entities;

public class UserRole  //Note: Arver ikke fra Entity, da Primary Key er UserId
{
    internal UserRole()
    {
    }

    public UserRole(Guid userId, Guid roleId, RoleDates roleDates)
    {
        UserId = userId;
        RoleId = roleId;
        RoleDates = roleDates;
    }

    public Guid UserId { get; set; }  //Primary Key sat af EF
    public User User { get; set; }
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    public RoleDates RoleDates { get; set; }
    public byte[] RowVersion { get; set; }  //Note: Arver ikke fra Entity

    public static UserRole Create(Guid userId, Guid roleId, RoleDates roleDates)
    {
        if (roleDates == null) throw new ArgumentNullException(nameof(roleDates));

        var userRole = new UserRole(userId, roleId, roleDates);

        return userRole;
    }

    public void Update(Guid userId, Guid roleId, RoleDates roleDates)
    {
        if (roleDates == null) throw new ArgumentNullException(nameof(roleDates));

        this.RoleDates = roleDates;
    }
}
