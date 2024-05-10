using UnikProjekt.Domain.Shared;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Entities;

public class User : Entity
{
    internal User() : base(Guid.NewGuid())
    {
    }

    internal User(Guid id, Name name, EmailAddress email, MobileNumber mobileNumber) : base(id)
    {
        //TODO: INA: Add address
        Name = name;
        Email = email;
        MobileNumber = mobileNumber;
    }

    public Name Name { get; set; }
    public EmailAddress Email { get; init; }   //TODO: INA: Find ud af om den skal være init?
    public MobileNumber MobileNumber { get; init; }

    public static User Create(Name name, EmailAddress emailAddress, MobileNumber mobileNumber)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (emailAddress == null) throw new ArgumentNullException(nameof(emailAddress));
        if (mobileNumber == null) throw new ArgumentNullException(nameof(mobileNumber));

        var user = new User(Guid.NewGuid(), name, emailAddress, mobileNumber);

        return user;
    }
}
