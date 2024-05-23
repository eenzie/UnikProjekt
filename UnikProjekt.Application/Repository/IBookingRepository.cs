using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Repository;

public interface IBookingRepository
{
    Booking GetBooking(Guid id);
    Guid AddBooking(Booking booking);
    void UpdateBooking(Booking booking, byte[] rowVersion);
}
