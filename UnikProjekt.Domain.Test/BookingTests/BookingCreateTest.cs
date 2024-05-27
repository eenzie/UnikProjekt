using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Domain.Value;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Domain.Test.BookingTests;

public class BookingCreateTest
{
    [Theory]
    [InlineData("2024-05-01", "2024-05-02", "2024-05-03", "2024-05-04")]
    public void Create_BookingLineWithNoOverlappingBookings_BookingLineIsCreated(
        string startDate, string endDate, string otherStartDate, string otherEndDate)
    {
        // Arrange
        var validNameMock = new Mock<Name>("John", "Doe");
        var validEmailValue = "john@example.com";
        var validEmailMock = new Mock<EmailAddress>(validEmailValue);
        var validMobileNumberValue = "12345678";
        var validmobileNumberMock = new Mock<MobileNumber>(validMobileNumberValue);
        var validAddressMock = new Mock<Address>("Sønderbrogade", "38 st. 4", "8700", "Horsens");

        var userMock = User.Create(Guid.NewGuid(), validNameMock.Object, validEmailMock.Object, validmobileNumberMock.Object, validAddressMock.Object);

        var bookingItemName = "Hækkeklipper";
        var bookingItemPrice = 50.2M;
        var bookingItemDeposit = 0;
        var bookingItemIntervalStart = new TimeOnly(8, 0);
        var bookingItemIntervalEnd = new TimeOnly(20, 0);
        var bookingItemBookingTimeInMinutes = 60;
        var bookingItemMock = BookingItem.Create(bookingItemName, bookingItemPrice, bookingItemDeposit,
                                                 bookingItemIntervalStart, bookingItemIntervalEnd, bookingItemBookingTimeInMinutes);

        var services = new MockProvider();
        var bookingDomainServiceMock = new Mock<IBookingDomainService>();
        //var mockContext = new Mock<UnikDbContext>();
        //services.Add(mockContext);

        var bookingLines = new List<BookingLine>(); // This gets added and tested in Act        
        var otherBookingLines = new List<BookingLine>();
        //mockContext.Object.Add(BookingLine.Create(bookingItemMock, DateTime.Parse(otherStartDate), DateTime.Parse(otherEndDate), bookingDomainServiceMock.Object));
        otherBookingLines.Add(BookingLine.Create(bookingItemMock, DateTime.Parse(otherStartDate), DateTime.Parse(otherEndDate), bookingDomainServiceMock.Object));

        bookingDomainServiceMock.Setup(b => b.IsBookingLineOverlapping(It.IsAny<BookingLine>()));
        services.Add(bookingDomainServiceMock);

        // Act
        bookingLines.Add(BookingLine.Create(bookingItemMock, DateTime.Parse(startDate), DateTime.Parse(endDate), bookingDomainServiceMock.Object));
        var sut = Booking.Create(userMock, DateTime.Now, bookingLines);

        // Assert
        Assert.NotEmpty(bookingLines);
        Assert.NotNull(sut);
    }

    [Theory]
    [InlineData("2024-05-01", "2024-05-03", "2024-05-02", "2024-05-04")]
    public void Create_BookingLineWithOverlappingBookings_ExceptionIsThrown(
        string startDate, string endDate, string otherStartDate, string otherEndDate)
    {
        // Arrange
        var validNameMock = new Mock<Name>("John", "Doe");
        var validEmailValue = "john@example.com";
        var validEmailMock = new Mock<EmailAddress>(validEmailValue);
        var validMobileNumberValue = "12345678";
        var validmobileNumberMock = new Mock<MobileNumber>(validMobileNumberValue);
        var validAddressMock = new Mock<Address>("Sønderbrogade", "38 st. 4", "8700", "Horsens");

        var userMock = User.Create(Guid.NewGuid(), validNameMock.Object, validEmailMock.Object, validmobileNumberMock.Object, validAddressMock.Object);

        var bookingItemName = "Hækkeklipper";
        var bookingItemPrice = 50.2M;
        var bookingItemDeposit = 0;
        var bookingItemIntervalStart = new TimeOnly(8, 0);
        var bookingItemIntervalEnd = new TimeOnly(20, 0);
        var bookingItemBookingTimeInMinutes = 60;
        var bookingItemMock = BookingItem.Create(bookingItemName, bookingItemPrice, bookingItemDeposit,
                                                 bookingItemIntervalStart, bookingItemIntervalEnd, bookingItemBookingTimeInMinutes);

        var services = new MockProvider();
        var bookingDomainServiceMock = new Mock<IBookingDomainService>();

        var bookingLines = new List<BookingLine>(); // This gets added and tested in Act        
        var otherBookingLines = new List<BookingLine>();
        otherBookingLines.Add(BookingLine.Create(bookingItemMock, DateTime.Parse(otherStartDate), DateTime.Parse(otherEndDate), bookingDomainServiceMock.Object));

        bookingDomainServiceMock.Setup(b => b.IsBookingLineOverlapping(bookingLines.FirstOrDefault()));
        services.Add(bookingDomainServiceMock);

        // Act
        bookingLines.Add(BookingLine.Create(bookingItemMock, DateTime.Parse(startDate), DateTime.Parse(endDate), bookingDomainServiceMock.Object));

        // Assert
        Assert.Throws<ArgumentException>(() => BookingLine.Create(bookingItemMock, DateTime.Parse(startDate), DateTime.Parse(endDate), bookingDomainServiceMock.Object));
    }
}
