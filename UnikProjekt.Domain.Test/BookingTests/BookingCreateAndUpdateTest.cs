using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Test.BookingTests;

public class BookingCreateAndUpdateTest
{
    //[Theory]
    //[InlineData("2021-01-01", "2021-01-02", "2021-01-03", "2021-01-04")]
    //public void Given__Booking_Is_Not_Overlapping_With_Other_Bookings__When_Creating_Booking__Then_Booking_Is_Created(
    //    string startDate, string endDate, string otherStartDate, string otherEndDate)
    //{
    //    // Arrange
    //    var accommodationMock =
    //        new Mock<Accommodation>(It.IsAny<Guid>(), It.IsAny<Address>(), It.IsAny<double>())
    //            .Object;
    //    var userMock =
    //        new Mock<User>(It.IsAny<Guid>(), It.IsAny<EmailAddress>(), It.IsAny<Name>())
    //            .Object;
    //    var otherBooking = new Booking(Guid.NewGuid(), accommodationMock, userMock,
    //        new BookingDates(DateOnly.Parse(otherStartDate),
    //            DateOnly.Parse(otherEndDate)));
    //    var otherBookings = new List<Booking> { otherBooking };

    //    var services = new MockProvider();
    //    var bookingDomainServiceMock = new Mock<IBookingDomainService>();
    //    bookingDomainServiceMock.Setup(b => b.OtherBookings(It.IsAny<Booking>())).Returns(otherBookings);
    //    services.Add(bookingDomainServiceMock);

    //    // Act
    //    var sut = Booking.Create(accommodationMock, userMock, new BookingDates(DateOnly.Parse(startDate),
    //        DateOnly.Parse(endDate)), services);
    //    // Assert
    //    Assert.NotNull(sut);
    //}

    //[Theory]
    //[InlineData("2021-01-01", "2021-01-02", "2021-01-02", "2021-01-04")]
    //public void Given__Booking_Is_Overlapping_With_Other_Bookings__When_Creating_Booking__Then_Exception_Is_Thrown(
    //    string startDate, string endDate, string otherStartDate, string otherEndDate)
    //{
    //    // Arrange
    //    var accommodationMock =
    //        new Mock<Accommodation>(It.IsAny<Guid>(), It.IsAny<Address>(), It.IsAny<double>())
    //            .Object;
    //    var userMock =
    //        new Mock<User>(It.IsAny<Guid>(), It.IsAny<EmailAddress>(), It.IsAny<Name>())
    //            .Object;
    //    var otherBooking = new Booking(Guid.NewGuid(), accommodationMock, userMock,
    //        new BookingDates(DateOnly.Parse(otherStartDate),
    //            DateOnly.Parse(otherEndDate)));
    //    var otherBookings = new List<Booking> { otherBooking };

    //    var services = new MockProvider();
    //    var bookingDomainServiceMock = new Mock<IBookingDomainService>();
    //    bookingDomainServiceMock.Setup(b => b.OtherBookings(It.IsAny<Booking>())).Returns(otherBookings);
    //    services.Add(bookingDomainServiceMock);

    //    // Act
    //    // Assert
    //    Assert.Throws<InvalidOperationException>(() => Booking.Create(accommodationMock, userMock, new BookingDates(
    //        DateOnly.Parse(startDate),
    //        DateOnly.Parse(endDate)), services));
    //}
}
