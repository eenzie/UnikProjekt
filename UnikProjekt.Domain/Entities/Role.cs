﻿using UnikProjekt.Domain.Shared;

namespace UnikProjekt.Domain.Entities;

public class Role : Entity
{
    internal Role()
    {
    }

    public Role(Guid id, string rolename)
    {
        RoleName = rolename;

    }

    public string RoleName { get; set; }
    public List<UserRole>? UserRoles { get; set; }

    public static Role Create(string roleName)
    {
        if (roleName == null) throw new ArgumentNullException(nameof(roleName));

        return new Role(Guid.NewGuid(), roleName);
    }

    public void Update(string roleName)
    {
        if (roleName == null) throw new ArgumentNullException(nameof(roleName));

        this.RoleName = roleName;
    }
}
