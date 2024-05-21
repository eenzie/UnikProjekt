using UnikProjekt.Application.Queries.DTOs;

namespace UnikProjekt.Application.Queries;

public interface IBookingQueries
{
    IEnumerable<BookingDto> GetAllBookings();
    BookingDto? GetBookingById(Guid bookingId);
    IEnumerable<BookingDto> GetBookingByUser(Guid userId);
}
