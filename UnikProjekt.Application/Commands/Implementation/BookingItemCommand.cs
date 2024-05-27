using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Commands.Implementation
{
    public class BookingItemCommand : IBookingItemCommand
    {
        private readonly IUnitOfWork _uow;
        private readonly IBookingItemRepository _bookingItemRepository;
        private readonly IServiceProvider _serviceProvider;

        public BookingItemCommand(IUnitOfWork uow, IBookingItemRepository bookingItemRepository, IServiceProvider serviceProvider)
        {
            _uow = uow;
            _bookingItemRepository = bookingItemRepository;
            _serviceProvider = serviceProvider;
        }

        public Guid CreateBookingItem(CreateBookingItemDto createBookingItemDto)
        {
            try
            {
                _uow.BeginTransaction();

                var bookingItem = BookingItem.Create(createBookingItemDto.ServiceName, 
                                                     createBookingItemDto.Price,
                                                     createBookingItemDto.Deposit,
                                                     createBookingItemDto.IntervalStart,
                                                     createBookingItemDto.IntervalEnd,
                                                     createBookingItemDto.BookingTimeInMinutes);

                _bookingItemRepository.AddBookingItem(bookingItem);

                _uow.Commit();

                return bookingItem.Id;
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

        public Guid UpdateBookingItem(UpdateBookingItemDto updateBookingItemDto)
        {
            try
            {
                _uow.BeginTransaction();

                var bookingItem = _bookingItemRepository.GetBookingItem(updateBookingItemDto.Id);
                bookingItem.Update(updateBookingItemDto.ServiceName,
                                                     updateBookingItemDto.Price,
                                                     updateBookingItemDto.Deposit,
                                                     updateBookingItemDto.IntervalStart,
                                                     updateBookingItemDto.IntervalEnd,
                                                     updateBookingItemDto.BookingTimeInMinutes);

                bookingItem.RowVersion = updateBookingItemDto.RowVersion;

                _bookingItemRepository.UpdateBookingItem(bookingItem, bookingItem.RowVersion);

                _uow.Commit();

                return bookingItem.Id;
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
}
