using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Entities;

public class User
{
    //Note: User entity arver ikke fra Entity, da Guid bliver oprettet af Identity i UI
    //og overdrages ved CreateUser
    internal User()
    {
    }

    internal User(Guid id, Name name, EmailAddress email, MobileNumber mobileNumber, Address address)
    {
        Id = id;
        Name = name;
        Email = email;
        MobileNumber = mobileNumber;
        Address = address;
    }
    public Guid Id { get; set; }  //Note: Arver ikke fra Entity
    public Name Name { get; set; }
    public EmailAddress Email { get; set; }
    public MobileNumber MobileNumber { get; set; }
    public Address Address { get; set; }
    public List<UserRole> UserRoles { get; set; }
    public byte[] RowVersion { get; set; }

    public static User Create(Guid id, Name name, EmailAddress emailAddress, MobileNumber mobileNumber, Address address)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (emailAddress == null) throw new ArgumentNullException(nameof(emailAddress));
        if (mobileNumber == null) throw new ArgumentNullException(nameof(mobileNumber));
        if (address == null) throw new ArgumentNullException(nameof(address));

        var user = new User(id, name, emailAddress, mobileNumber, address);

        return user;
    }
    public void Update(Name name, EmailAddress emailAddress, MobileNumber mobileNumber, Address address)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (emailAddress == null) throw new ArgumentNullException(nameof(emailAddress));
        if (mobileNumber == null) throw new ArgumentNullException(nameof(mobileNumber));
        if (address == null) throw new ArgumentNullException(nameof(address));

        this.Name = name;
        this.Email = emailAddress;
        this.MobileNumber = mobileNumber;
        this.Address = address;
    }
}
