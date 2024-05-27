using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Queries
{
    public class BookingQueries : IBookingQueries
    {
        private readonly UnikDbContext _context;

        public BookingQueries(UnikDbContext context)
        {
            _context = context;
        }

        IEnumerable<BookingDto> IBookingQueries.GetAllBookings()
        {
            var bookings = _context.Bookings.AsNoTracking()
                .Include(x => x.User)
                .Include(x => x.Items)
                .ThenInclude(x => x.BookingItem)
                .Select(x => new BookingDto
                {
                    Id = x.Id,
                    User = new UserDto()
                    {
                        Id = x.User.Id,
                        FirstName = x.User.Name.FirstName.ToString(),
                        LastName = x.User.Name.LastName.ToString(),
                        Email = x.User.Email.ToString(),
                        MobileNumber = x.User.MobileNumber.ToString(),
                        Street = x.User.Address.Street.ToString(),
                        StreetNumber = x.User.Address.StreetNumber.ToString(),
                        PostCode = x.User.Address.PostCode.ToString(),
                        City = x.User.Address.City.ToString(),
                        RowVersion = x.User.RowVersion
                    },
                    DateBooked = x.DateBooked,
                    Items = x.Items.Select(x => new BookingLineDto
                    {
                        Id = x.Id,
                        BookingItem = new BookingItemDto()
                        {
                            Id = x.BookingItem.Id,
                            ServiceName = x.BookingItem.ServiceName,
                            Price = x.BookingItem.Price,
                            Deposit = x.BookingItem.Deposit,
                            IntervalStart = x.BookingItem.IntervalStart, //TODO: Add TimeOnly.FromTimeSpan when tables are created
                            IntervalEnd = x.BookingItem.IntervalEnd,
                            BookingTimeInMinutes = x.BookingItem.BookingTimeInMinutes,
                            TimeSlots = x.BookingItem.TimeSlots,
                            RowVersion = x.BookingItem.RowVersion
                        }
                    }).ToList(),
                    SubTotal = x.SubTotal,
                    TotalPrice = x.TotalPrice,
                    RowVersion = x.RowVersion
                })
                .ToList();

            return bookings;
        }

        BookingDto? IBookingQueries.GetBookingById(Guid bookingId)
        {
            var booking = _context.Bookings.AsNoTracking()
               .Include(x => x.User)
               .Include(x => x.Items)
               .ThenInclude(x => x.BookingItem)
               .Where(x => x.Id == bookingId)
               .Select(x => new BookingDto
               {
                   Id = x.Id,
                   User = new UserDto()
                   {
                       Id = x.User.Id,
                       FirstName = x.User.Name.FirstName.ToString(),
                       LastName = x.User.Name.LastName.ToString(),
                       Email = x.User.Email.ToString(),
                       MobileNumber = x.User.MobileNumber.ToString(),
                       Street = x.User.Address.Street.ToString(),
                       StreetNumber = x.User.Address.StreetNumber.ToString(),
                       PostCode = x.User.Address.PostCode.ToString(),
                       City = x.User.Address.City.ToString(),
                       RowVersion = x.User.RowVersion
                   },
                   DateBooked = x.DateBooked,
                   Items = x.Items.Select(x => new BookingLineDto
                   {
                       Id = x.Id,
                       BookingItem = new BookingItemDto()
                       {
                           Id = x.BookingItem.Id,
                           ServiceName = x.BookingItem.ServiceName,
                           Price = x.BookingItem.Price,
                           Deposit = x.BookingItem.Deposit,
                           IntervalStart = x.BookingItem.IntervalStart, //TODO: Add TimeOnly.FromTimeSpan when tables are created
                           IntervalEnd = x.BookingItem.IntervalEnd,
                           BookingTimeInMinutes = x.BookingItem.BookingTimeInMinutes,
                           TimeSlots = x.BookingItem.TimeSlots,
                           RowVersion = x.BookingItem.RowVersion
                       }
                   }).ToList(),
                   SubTotal = x.SubTotal,
                   TotalPrice = x.TotalPrice,
                   RowVersion = x.RowVersion
               })
               .FirstOrDefault();

            return booking;
        }

        IEnumerable<BookingDto> IBookingQueries.GetBookingByUser(Guid userId)
        {
            var bookings = _context.Bookings.AsNoTracking()
               .Include(x => x.User)
               .Include(x => x.Items)
               .ThenInclude(x => x.BookingItem)
               .Where(x => x.User.Id == userId)
               .Select(x => new BookingDto
               {
                   Id = x.Id,
                   User = new UserDto()
                   {
                       Id = x.User.Id,
                       FirstName = x.User.Name.FirstName.ToString(),
                       LastName = x.User.Name.LastName.ToString(),
                       Email = x.User.Email.ToString(),
                       MobileNumber = x.User.MobileNumber.ToString(),
                       Street = x.User.Address.Street.ToString(),
                       StreetNumber = x.User.Address.StreetNumber.ToString(),
                       PostCode = x.User.Address.PostCode.ToString(),
                       City = x.User.Address.City.ToString(),
                       RowVersion = x.User.RowVersion
                   },
                   DateBooked = x.DateBooked,
                   Items = x.Items.Select(x => new BookingLineDto
                   {
                       Id = x.Id,
                       BookingItem = new BookingItemDto()
                       {
                           Id = x.BookingItem.Id,
                           ServiceName = x.BookingItem.ServiceName,
                           Price = x.BookingItem.Price,
                           Deposit = x.BookingItem.Deposit,
                           IntervalStart = x.BookingItem.IntervalStart, //TODO: Add TimeOnly.FromTimeSpan when tables are created
                           IntervalEnd = x.BookingItem.IntervalEnd,
                           BookingTimeInMinutes = x.BookingItem.BookingTimeInMinutes,
                           TimeSlots = x.BookingItem.TimeSlots,
                           RowVersion = x.BookingItem.RowVersion
                       }
                   }).ToList(),
                   SubTotal = x.SubTotal,
                   TotalPrice = x.TotalPrice,
                   RowVersion = x.RowVersion
               })
               .ToList();

            return bookings;
        }
    }
}
