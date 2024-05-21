
using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Repository;

namespace UnikProjekt.Application.Commands.Implementation;

public class BookingCommand : IBookingCommand
{
    //TODO: Implement commands
    private readonly IUnitOfWork _uow;
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IServiceProvider _serviceProvider;

    public BookingCommand(IUnitOfWork uow, IBookingRepository bookingRepository, IServiceProvider serviceProvider)
    {
        _uow = uow;
        _bookingRepository = bookingRepository;
        _serviceProvider = serviceProvider;
    }

    public Guid CreateBooking(CreateBookingDto createBookingDto)
    {
        _uow.BeginTransaction();



        return Guid.NewGuid();
    }

    public Guid UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        throw new NotImplementedException();
    }
}
