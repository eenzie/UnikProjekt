using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Application.Commands.DTOs;

namespace UnikProjekt.Application.Commands
{
    public interface IBookingItemCommand
    {
        Guid CreateBookingItem(CreateBookingItemDto createBookingItemDto);
        Guid UpdateBookingItem(UpdateBookingItemDto updateBookingItemDto);
    }
}
