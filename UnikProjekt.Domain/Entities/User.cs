using UnikProjekt.Domain.Shared;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Entities;

public class User : Entity
{
    internal User() : base(Guid.NewGuid())
    {
    }

    public User(Guid id, EmailAddress email, Name name, MobileNumber mobileNumber) : base(id)
    {
        Email = email;
        Name = name;
        MobileNumber = mobileNumber;
    }

    public Name Name { get; init; }
    public EmailAddress Email { get; init; }   //TODO: INA: Find ud af om den skal være init?
    public MobileNumber MobileNumber { get; init; }
}
