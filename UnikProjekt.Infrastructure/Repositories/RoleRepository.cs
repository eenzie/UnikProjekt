﻿using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly UnikDbContext _context;

    public RoleRepository(UnikDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets Roles from string list of roles. Such as on Create/Update User
    /// </summary>
    /// <param name="roles"></param>
    /// <returns>Listof Role Entity</returns>
    List<Role> IRoleRepository.GetRoles(List<string> roleIds)
    {
        if (roleIds == null || !roleIds.Any())
        {
            // If roleIds is null or empty, return an empty list
            return new List<Role>();
        }

        var result = new List<Role>();

        foreach (var roleId in roleIds)
        {
            if (Guid.TryParse(roleId, out var roleIdGuid))
            {
                // Query the database for the role with the converted roleIdGuid
                var role = _context.Roles.FirstOrDefault(x => x.Id == roleIdGuid);

                if (role != null)
                {
                    result.Add(role);
                }
                else
                {
                    Console.WriteLine($"Role not found with id: {roleId}");
                }
            }
            else
            {
                Console.WriteLine($"Invalid role ID format: {roleId}");
            }
        }
        return result;
    }

    Role IRoleRepository.GetRole(Guid roleId)
    {
        return _context.Roles.Find(roleId) ?? throw new Exception("Role not found");
    }

    Guid IRoleRepository.AddRole(Role role)
    {
        _context.Roles.Add(role);
        _context.SaveChanges();
        return role.Id;
    }

    void IRoleRepository.UpdateRole(Role role, byte[] rowVersion)
    {
        _context.Entry(role).Property(p => p.RowVersion).OriginalValue = rowVersion;
        _context.SaveChanges();
    }
}
