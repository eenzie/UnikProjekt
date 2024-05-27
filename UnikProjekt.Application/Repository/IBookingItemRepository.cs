using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Repository
{
    public interface IBookingItemRepository
    {
        BookingItem GetBookingItem(Guid id);
        Guid AddBookingItem(BookingItem bookingItem);
        void UpdateBookingItem(BookingItem bookingItem, byte[] rowVersion);
    }
}
