
using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Commands.Implementation;

public class BookingCommand : IBookingCommand
{
    //TODO: Implement commands
    private readonly IUnitOfWork _uow;
    private readonly IBookingRepository _bookingRepository;
    private readonly IBookingItemRepository _bookingItemRepository;
    private readonly IUserRepository _userRepository;
    private readonly IServiceProvider _serviceProvider;

    public BookingCommand(IUnitOfWork uow, IBookingRepository bookingRepository, IServiceProvider serviceProvider, IUserRepository userRepository, IBookingItemRepository bookingItemRepository)
    {
        _uow = uow;
        _bookingRepository = bookingRepository;
        _bookingItemRepository = bookingItemRepository;
        _userRepository = userRepository;
        _serviceProvider = serviceProvider;
    }

    Guid IBookingCommand.CreateBooking(CreateBookingDto createBookingDto)
    {
        
        try
        {
            _uow.BeginTransaction();

            var user = _userRepository.GetUser(createBookingDto.UserId);

            var bookingLines = createBookingDto.Items.Select(x => BookingLine.Create
                (
                _bookingItemRepository.GetBookingItem(x.BookingItemId), x.BookingStart, x.BookingEnd
                )).ToList();

            var booking = Booking.Create(user, createBookingDto.DateBooked, bookingLines, createBookingDto.BookingComment);

            _bookingRepository.AddBooking(booking);

            _uow.Commit();

            return booking.Id;
        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Rollback failed: {ex.Message}", e);
            }
            throw;
        }
    }

    public Guid UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        try
        {
            _uow.BeginTransaction();

            var booking = _bookingRepository.GetBooking(updateBookingDto.Id);

            if (booking == null)
            {
                throw new Exception("Booking not found");
            }

            var user = _userRepository.GetUser(updateBookingDto.UserId);

            //TODO: Figure out logic for updating lines in booking
            //booking.Items.ForEach(BookingLine.Update(_bookingItemRepository.GetBookingItem(),
            //                                                                    BookingStart,
            //                                                                    BookingEnd)).ToList();

            var bookingLines = new List<BookingLine>();

            booking.Update(user, updateBookingDto.DateBooked, bookingLines, updateBookingDto.BookingComment);
            booking.RowVersion = updateBookingDto.RowVersion;

            _bookingRepository.UpdateBooking(booking, booking.RowVersion);

            _uow.Commit();

            return booking.Id;
        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Rollback failed: {ex.Message}", e);
            }
            throw;
        }

    }
}
