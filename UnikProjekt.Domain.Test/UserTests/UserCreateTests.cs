using Moq;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Test.UserTest;

public class UserCreateTests
{
    [Theory]
    [InlineData("Boulevarden", "25", "7100", "Vejle", true)]   // Valid address (Kat A)
    [InlineData("Bolevarden", "25", "7100", "Vejle", false)]   // "Valid" address (Kat B)
    [InlineData("Boulevarden", "45", "7100", "Vejle", false)]  // Invalid address (Kat C)
    public void Given__Address_Is_Validated__When_Creating_User__Then_User_Is_Created_Or_Exception_Thrown(
    string street, string streetNumber, string postCode, string city, bool isValidAddress)
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = new Name("Test", "User");
        var emailAddress = new EmailAddress("test@example.com");
        var mobileNumber = new MobileNumber("12345678");
        var address = new Address(street, streetNumber, postCode, city);

        var userDomainServiceMock = new Mock<IUserDomainService>();
        userDomainServiceMock.Setup(service => service.UserExistsWithEmail(It.IsAny<string>())).Returns(false);

        var addressDomainServiceMock = new Mock<IAddressDomainService>();
        addressDomainServiceMock.Setup(service => service.ValidateAddress(It.IsAny<Address>())).Returns(isValidAddress);

        // Act & Assert
        if (isValidAddress)
        {
            var user = User.Create(
                id,
                name,
                emailAddress,
                mobileNumber,
                address,
                userDomainServiceMock.Object,
                addressDomainServiceMock.Object
            );

            Assert.NotNull(user);
        }
        else
        {
            Assert.Throws<Exception>(() => User.Create(
                id,
                name,
                emailAddress,
                mobileNumber,
                address,
                userDomainServiceMock.Object,
                addressDomainServiceMock.Object
            ));
        }
    }

    [Theory]
    [InlineData("unique@example.com", false)]   // Email does not exist
    [InlineData("duplicate@example.com", true)] // Email already exists
    public void Given__Email_Is_Validated__When_Creating_User__Then_User_Is_Created_Or_Exception_Thrown(
    string email, bool emailExists)
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = new Name("Test", "User");
        var emailAddress = new EmailAddress(email);
        var mobileNumber = new MobileNumber("12345678");
        var address = new Address("ValidStreet", "123", "12345", "ValidCity");

        var userDomainServiceMock = new Mock<IUserDomainService>();
        userDomainServiceMock.Setup(service => service.UserExistsWithEmail(It.IsAny<string>())).Returns(emailExists);

        var addressDomainServiceMock = new Mock<IAddressDomainService>();
        addressDomainServiceMock.Setup(service => service.ValidateAddress(It.IsAny<Address>())).Returns(true);

        // Act & Assert
        if (emailExists)
        {
            Assert.Throws<ArgumentException>(() => User.Create(
                id,
                name,
                emailAddress,
                mobileNumber,
                address,
                userDomainServiceMock.Object,
                addressDomainServiceMock.Object
            ));
        }
        else
        {
            var user = User.Create(
                id,
                name,
                emailAddress,
                mobileNumber,
                address,
                userDomainServiceMock.Object,
                addressDomainServiceMock.Object
            );

            Assert.NotNull(user);
        }
    }

}