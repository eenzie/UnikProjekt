using UnikProjekt.Domain.Shared;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Entities;

public class User : Entity
{
    internal User() : base(Guid.NewGuid())
    {
    }

    public User(Guid id, EmailAddress email, Name name) : base(id)
    {
        Email = email;
        Name = name;
    }

    public Name Name { get; init; }
    public EmailAddress Email { get; init; }
}
