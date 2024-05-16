using UnikProjekt.Domain.Shared;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Entities;

public class User : Entity
{
    internal User()
    {

    }

    internal User(Guid id, Name name, EmailAddress email, MobileNumber mobileNumber, Address address, List<UserRole> userRoles)
    {
        Name = name;
        Email = email;
        MobileNumber = mobileNumber;
        Address = address;
        UserRoles = userRoles;
    }

    public Name Name { get; set; }
    public EmailAddress Email { get; set; }
    public MobileNumber MobileNumber { get; set; }
    public Address Address { get; set; }
    public List<UserRole> UserRoles { get; set; }

    public static User Create(Name name, EmailAddress emailAddress, MobileNumber mobileNumber, Address address, List<UserRole> userRoles)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (emailAddress == null) throw new ArgumentNullException(nameof(emailAddress));
        if (mobileNumber == null) throw new ArgumentNullException(nameof(mobileNumber));
        if (address == null) throw new ArgumentNullException(nameof(address));
        if (userRoles == null) throw new ArgumentNullException(nameof(userRoles));

        var user = new User(Guid.NewGuid(), name, emailAddress, mobileNumber, address, userRoles);

        return user;
    }
    public void Update(Name name, EmailAddress emailAddress, MobileNumber mobileNumber, Address address, List<UserRole> userRoles)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (emailAddress == null) throw new ArgumentNullException(nameof(emailAddress));
        if (mobileNumber == null) throw new ArgumentNullException(nameof(mobileNumber));
        if (address == null) throw new ArgumentNullException(nameof(address));
        if (userRoles == null) throw new ArgumentNullException(nameof(userRoles));

        this.Name = name;
        this.Email = emailAddress;
        this.MobileNumber = mobileNumber;
        this.Address = address;
    }
}
