using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Commands.Implementation;

public class BookingCommand : IBookingCommand
{
    private readonly IUnitOfWork _uow;
    private readonly IBookingRepository _bookingRepository;
    private readonly IBookingItemRepository _bookingItemRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBookingDomainService _bookingDomainService;
    private readonly IServiceProvider _services;

    public BookingCommand(IUnitOfWork uow, IBookingRepository bookingRepository, IServiceProvider services, IUserRepository userRepository, IBookingItemRepository bookingItemRepository, IBookingDomainService bookingDomainService)
    {
        _uow = uow;
        _bookingRepository = bookingRepository;
        _bookingItemRepository = bookingItemRepository;
        _userRepository = userRepository;
        _services = services;
        _bookingDomainService = bookingDomainService;
    }

    Guid IBookingCommand.CreateBooking(CreateBookingDto createBookingDto)
    {

        try
        {
            _uow.BeginTransaction();   //Default isolation level: Serializable

            var user = _userRepository.GetUser(createBookingDto.UserId);

            var bookingLines = createBookingDto.Items.Select(x => BookingLine.Create
                (
                _bookingItemRepository.GetBookingItem(x.BookingItemId), x.BookingStart, x.BookingEnd, _bookingDomainService
                )).ToList();


            var booking = Booking.Create(user, createBookingDto.DateBooked, bookingLines);

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

    Guid IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        try
        {
            _uow.BeginTransaction();   //Default isolation level: Serializable

            var booking = _bookingRepository.GetBooking(updateBookingDto.Id);

            if (booking == null)
            {
                throw new Exception("Booking not found");
            }

            var user = _userRepository.GetUser(updateBookingDto.UserId);

            //TODO: Figure out logic for updating lines in booking
            booking.Items.ForEach(x => x.Update(_bookingItemRepository.GetBookingItem(updateBookingDto.Items.Select(x => x.BookingItemId).FirstOrDefault()),
                                                                                updateBookingDto.Items.Select(x => x.BookingStart).FirstOrDefault(),
                                                                                updateBookingDto.Items.Select(x => x.BookingEnd).FirstOrDefault()));

            booking.Update(user, updateBookingDto.DateBooked, booking.Items);
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
    Guid IBookingCommand.DeleteSelectedBookingLines(UpdateBookingDto updateBookingDto)
    {
        try
        {
            _uow.BeginTransaction();   //Default isolation level: Serializable

            var booking = _bookingRepository.GetBooking(updateBookingDto.Id);

            if (booking == null)
            {
                throw new Exception("Booking not found");
            }

            var user = _userRepository.GetUser(updateBookingDto.UserId);

            booking.Update(user, updateBookingDto.DateBooked, booking.Items);
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
