using Moq;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Domain.Test.BookingTests;

public class BookingCreateTest
{
    [Theory]
    [InlineData("2021-01-01", "2021-01-02", "2021-01-01", "2021-01-02", true)] // Overlapping
    [InlineData("2021-01-01", "2021-01-02", "2021-01-03", "2021-01-04", false)] // Not overlapping
    public void Given__BookingLine_Is_Not_Overlapping_With_Other_BookingLines__When_Creating_BookingLine__Then_BookingLine_Is_Created(
    string startDate, string endDate, string otherStartDate, string otherEndDate, bool shouldOverlap)
    {
        // Arrange
        var bookingItem = new BookingItem(Guid.NewGuid(),
                                "Test Service",
                                100m,
                                50m,
                                new TimeOnly(9, 0),
                                new TimeOnly(17, 0),
                                60);

        var otherBookingLine = new BookingLine(Guid.NewGuid(),
                                               bookingItem,
                                               DateTime.Parse(otherStartDate),
                                               DateTime.Parse(otherEndDate)
        );

        var bookingDomainServiceMock = new Mock<IBookingDomainService>();

        bookingDomainServiceMock.Setup(service => service
                    .IsBookingLineOverlapping(It.IsAny<BookingLine>()))
                    .Returns(shouldOverlap);

        // Act & Assert
        if (shouldOverlap)
        {
            Assert.Throws<ArgumentException>(() =>
                BookingLine.Create(bookingItem,
                                   DateTime.Parse(startDate),
                                   DateTime.Parse(endDate),
                                   bookingDomainServiceMock.Object
                ));
        }
        else
        {
            var sut = BookingLine.Create(
                bookingItem,
                DateTime.Parse(startDate),
                DateTime.Parse(endDate),
                bookingDomainServiceMock.Object
            );

            Assert.NotNull(sut);
        }
    }
}
