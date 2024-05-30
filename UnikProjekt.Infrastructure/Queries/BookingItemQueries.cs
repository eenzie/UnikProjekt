using Microsoft.EntityFrameworkCore;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Queries
{
    public class BookingItemQueries : IBookingItemQueries
    {
        private readonly UnikDbContext _context;

        public BookingItemQueries(UnikDbContext context)
        {
            _context = context;
        }

        IEnumerable<BookingItemDto> IBookingItemQueries.GetAllBookingItems()
        {
            var bookingItems = _context.BookingItems.AsNoTracking()
                .Select(x => new BookingItemDto
                {
                    Id = x.Id,
                    ServiceName = x.ServiceName,
                    Price = x.Price,
                    Deposit = x.Deposit,
                    IntervalStart = x.IntervalStart,
                    IntervalEnd = x.IntervalEnd,
                    BookingTimeInMinutes = x.BookingTimeInMinutes,
                    TimeSlots = x.TimeSlots,
                    RowVersion = x.RowVersion
                })
                .ToList();

            return bookingItems;
        }

        BookingItemDto? IBookingItemQueries.GetBookingItemById(Guid bookingItemId)
        {
            var bookingItem = _context.BookingItems
                .AsNoTracking()   //LOAD
                .Where(x => x.Id == bookingItemId)
                .Select(x => new BookingItemDto
                {
                    Id = x.Id,
                    ServiceName = x.ServiceName,
                    Price = x.Price,
                    Deposit = x.Deposit,
                    IntervalStart = x.IntervalStart,
                    IntervalEnd = x.IntervalEnd,
                    BookingTimeInMinutes = x.BookingTimeInMinutes,
                    TimeSlots = x.TimeSlots,
                    RowVersion = x.RowVersion
                })
                .FirstOrDefault();

            return bookingItem;
        }

        IEnumerable<BookingItemDto> IBookingItemQueries.GetBookingItemByName(string searchTerm)
        {
            var result = _context.BookingItems
            .AsNoTracking()
                .Where(x => x.ServiceName.Contains(searchTerm))
                .Select(x => new BookingItemDto
                {
                    Id = x.Id,
                    ServiceName = x.ServiceName,
                    Price = x.Price,
                    Deposit = x.Deposit,
                    IntervalStart = x.IntervalStart,
                    IntervalEnd = x.IntervalEnd,
                    BookingTimeInMinutes = x.BookingTimeInMinutes,
                    TimeSlots = x.TimeSlots,
                    RowVersion = x.RowVersion
                })
                .ToList();

            return result;
        }
    }
}
