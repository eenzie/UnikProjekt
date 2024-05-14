using System.ComponentModel.DataAnnotations;
using UnikProjekt.Domain.Shared;

namespace UnikProjekt.Domain.Entities;

public class Role : Entity
{
    internal Role()
    {
    }

    public Role(Guid id, string rolename, int securityLevel)
    {
        RoleName = rolename;
        SecurityLevel = securityLevel;
    }

    public string RoleName { get; private set; }
    public int SecurityLevel { get; private set; }

    [Timestamp]
    public byte[] RowVersion { get; protected set; } = [];
}
