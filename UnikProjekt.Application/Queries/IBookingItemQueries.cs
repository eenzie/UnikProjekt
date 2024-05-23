using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Application.Queries.DTOs;

namespace UnikProjekt.Application.Queries
{
    public interface IBookingItemQueries
    {
        IEnumerable<BookingItemDto> GetAllBookingItems();
        BookingItemDto? GetBookingItemById(Guid bookingItemId);
        IEnumerable<BookingItemDto?> GetBookingItemByName(string searchTerm);
    }
}
