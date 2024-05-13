using System.ComponentModel.DataAnnotations;
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
    public EmailAddress Email { get; set; }
    public MobileNumber MobileNumber { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }

    public static User Create(Name name, EmailAddress emailAddress, MobileNumber mobileNumber)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (emailAddress == null) throw new ArgumentNullException(nameof(emailAddress));
        if (mobileNumber == null) throw new ArgumentNullException(nameof(mobileNumber));

        var user = new User(Guid.NewGuid(), name, emailAddress, mobileNumber);

        return user;
    }
    public void Update(Guid id, Name name, EmailAddress emailAddress, MobileNumber mobileNumber, byte[] rowVersion)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (emailAddress == null) throw new ArgumentNullException(nameof(emailAddress));
        if (mobileNumber == null) throw new ArgumentNullException(nameof(mobileNumber));

        this.Name = name;
        this.Email = emailAddress;
        this.MobileNumber = mobileNumber;
        this.RowVersion = rowVersion;
    }
}
