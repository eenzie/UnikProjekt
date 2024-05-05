using UnikProjekt.Domain.Shared;

namespace UnikProjekt.Domain.Entities;

public class Role : Entity
{
    internal Role() : base(Guid.NewGuid())
    {
    }

    public Role(Guid id, string rolename, int securityLevel) : base(id)
    {
        RoleName = rolename;
        SecurityLevel = securityLevel;
    }

    public string RoleName { get; private set; }
    public int SecurityLevel { get; private set; }
}
