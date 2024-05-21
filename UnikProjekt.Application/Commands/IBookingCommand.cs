using UnikProjekt.Application.Commands.DTOs;

namespace UnikProjekt.Application.Commands;

public interface IBookingCommand
{
    Guid CreateBooking(CreateBookingDto createBookingDto);
    Guid UpdateBooking(UpdateBookingDto updateBookingDto);
}
