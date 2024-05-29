using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.ProxyServices;

namespace UnikProjekt.Web.Services
{
    public class BookingItemService
    {
        private readonly IBookingServiceProxy _bookingServiceProxy;

        public BookingItemService(IBookingServiceProxy bookingServiceProxy)
        {
            _bookingServiceProxy = bookingServiceProxy;
        }

        public async Task<IEnumerable<BookingItemViewModel>> GetAllBookingItemsAsync()
        {
            var bookingItemDtos = await _bookingServiceProxy.GetAllBookingItemsAsync();
            if (bookingItemDtos == null)
            {
                return null;
            }

            var bookingItemViewModels = bookingItemDtos.Select(bookingItemDtos => new BookingItemViewModel
            {
                Id = bookingItemDtos.Id,
                ServiceName = bookingItemDtos.ServiceName,
                Price = bookingItemDtos.Price,
                Deposit = bookingItemDtos.Deposit,
                IntervalStart = bookingItemDtos.IntervalStart,
                IntervalEnd = bookingItemDtos.IntervalEnd,
                BookingTimeInMinutes = bookingItemDtos.BookingTimeInMinutes
            });

            return bookingItemViewModels;
        }

        public async Task<BookingItemViewModel> GetBookingItemByIdAsync(Guid id)
        {
            var bookingItemDtos = await _bookingServiceProxy.GetBookingItemByIdAsync(id);
            if (bookingItemDtos == null)
            {
                return null;
            }
            return new BookingItemViewModel
            {
                Id = bookingItemDtos.Id,
                ServiceName = bookingItemDtos.ServiceName,
                Price = bookingItemDtos.Price,
                Deposit = bookingItemDtos.Deposit,
                IntervalStart = bookingItemDtos.IntervalStart,
                IntervalEnd = bookingItemDtos.IntervalEnd,
                BookingTimeInMinutes = bookingItemDtos.BookingTimeInMinutes,
                RowVersion = bookingItemDtos.RowVersion,
            };
        }

        public async Task<IEnumerable<BookingItemViewModel>> GetBookingItemByNameAsync(string name)
        {
            var bookingItemDtos = await _bookingServiceProxy.GetBookingItemByNameAsync(name);
            return bookingItemDtos.Select(bookingItemDtos => new BookingItemViewModel
            {
                ServiceName = bookingItemDtos.ServiceName,
                Price = bookingItemDtos.Price,
                Deposit = bookingItemDtos.Deposit,
                IntervalStart = bookingItemDtos.IntervalStart,
                IntervalEnd = bookingItemDtos.IntervalEnd,
                BookingTimeInMinutes = bookingItemDtos.BookingTimeInMinutes,
                RowVersion = bookingItemDtos.RowVersion,
            });
        }

        public async Task<Guid> CreateBookingItemAsync(CreateBookingItemDto createBookingItemDto)
        {
            var bookingItemDto = await _bookingServiceProxy.CreateBookingItemAsync(createBookingItemDto);
            if (bookingItemDto == null)
            {
                return Guid.Empty;
            }

            return bookingItemDto.Id;
        }

        public async Task<Guid> EditBookingItemAsync(Guid id, EditBookingItemDto editBookingItemDto)
        {
            var editedBookingItemDto = await _bookingServiceProxy.EditBookingItemAsync(editBookingItemDto);
            if (editedBookingItemDto == null)
            {
                return Guid.Empty;
            }
            return editedBookingItemDto.Id;
        }
    }
}