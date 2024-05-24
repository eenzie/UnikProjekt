using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Domain.DomainService;

public interface IBookingDomainService
{
    IEnumerable<BookingLine> OtherBookings(Booking booking);
}
