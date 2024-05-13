using Moq;
using UnikProjekt.Domain.Entities;


namespace UnikProjekt.Domain.Test.UserTest;

public class UserCreateAndUpdateTests
{
    [Theory]
    [InlineData("FirstName", "LastName", "first@last.com", "12345678")]
    public void Given_Data_Is_Valid__When_Creating_New_User__Then_User_Is_Created(string firstName, string lastName, string email, string mobile)
    {
        // Arrange
        var userMock = new Mock<User>(firstName, lastName, email, mobile);

        // Act
        var sut = User.Create(userMock.Object);

        //Assert
    }
}
