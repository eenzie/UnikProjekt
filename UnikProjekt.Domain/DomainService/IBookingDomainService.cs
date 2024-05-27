using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Domain.DomainService;

public interface IBookingDomainService
{
    bool IsBookingLineOverlapping(BookingLine bookingLine);
}
