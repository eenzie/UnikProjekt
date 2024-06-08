using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.ProxyServices;

namespace UnikProjekt.Web.Services
{
    public class BookingService
    {
        private readonly IBookingServiceProxy _bookingServiceProxy;

        public BookingService(IBookingServiceProxy bookingServiceProxy)
        {
            _bookingServiceProxy = bookingServiceProxy;

        }

        public async Task<IEnumerable<BookingViewModel>> GetAllBookingsAsync()
        {
            var bookingDtos = await _bookingServiceProxy.GetAllBookingsAsync();

            if (bookingDtos == null)
            {
                return null;
            }

            var bookingViewModels = bookingDtos.SelectMany(bookingDto => bookingDto.Items.Select(item => new BookingViewModel
            {
                Id = bookingDto.Id,
                User = bookingDto.User,
                DateBooked = bookingDto.DateBooked,
                SubTotal = bookingDto.SubTotal,
                TotalPrice = bookingDto.TotalPrice,
                Items = new List<BookingLineViewModel>
        {
            new BookingLineViewModel
            {
                Id = item.Id,
                BookingItem = item.BookingItem,
                BookingStart = item.BookingStart,
                BookingEnd = item.BookingEnd,
                ItemPrice = item.ItemPrice
            }
        }
            }));

            return bookingViewModels;
        }

        public async Task<BookingViewModel> GetBookingByIdAsync(Guid id)
        {
            var bookingDto = await _bookingServiceProxy.GetBookingByIdAsync(id);
            if (bookingDto == null)
            {
                return null;
            }
            var bookingViewModel = new BookingViewModel
            {
                Id = bookingDto.Id,
                User = bookingDto.User,
                DateBooked = bookingDto.DateBooked,
                SubTotal = bookingDto.SubTotal,
                TotalPrice = bookingDto.TotalPrice,
                Items = bookingDto.Items.Select(item => new BookingLineViewModel
                {
                    Id = item.Id,
                    BookingItem = item.BookingItem,
                    BookingStart = item.BookingStart,
                    BookingEnd = item.BookingEnd,
                    ItemPrice = item.ItemPrice
                }).ToList(),
                RowVersion = bookingDto.RowVersion
            };

            return bookingViewModel;
        }

        public async Task<IEnumerable<BookingViewModel>> GetBookingByNameAsync(string name)
        {
            var bookingDtos = await _bookingServiceProxy.GetBookingByNameAsync(name);

            if (bookingDtos == null)
            {
                return null;
            }

            var bookingViewModels = bookingDtos.Select(bookingDto => new BookingViewModel
            {
                User = bookingDto.User,
                DateBooked = bookingDto.DateBooked,
                Items = bookingDto.Items.Select(item => new BookingLineViewModel
                {
                    Id = item.Id,
                    BookingItem = item.BookingItem,
                    BookingStart = item.BookingStart,
                    BookingEnd = item.BookingEnd,
                    ItemPrice = item.ItemPrice
                }).ToList(),
                SubTotal = bookingDto.SubTotal,
                TotalPrice = bookingDto.TotalPrice,
                RowVersion = bookingDto.RowVersion
            });

            return bookingViewModels;
        }

        public async Task<Guid> CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            var bookingDto = await _bookingServiceProxy.CreateBookingAsync(createBookingDto);
            if (bookingDto == null)
            {
                return Guid.Empty;
            }

            return bookingDto.Id;

        }

        public async Task<BookingViewModel> EditBookingAsync(EditBookingDto editBookingDto)
        {
            var bookingDto = await _bookingServiceProxy.EditBookingAsync(editBookingDto);
            if (bookingDto == null)
            {
                return null;
            }

            var bookingViewModel = new BookingViewModel
            {
                Id = bookingDto.Id,
                User = bookingDto.User,
                DateBooked = bookingDto.DateBooked,
                SubTotal = bookingDto.SubTotal,
                TotalPrice = bookingDto.TotalPrice,
                Items = bookingDto.Items.Select(item => new BookingLineViewModel
                {
                    Id = item.Id,
                    BookingItem = item.BookingItem,
                    BookingStart = item.BookingStart,
                    BookingEnd = item.BookingEnd,
                    ItemPrice = item.ItemPrice
                }).ToList(),
                RowVersion = bookingDto.RowVersion
            };

            return bookingViewModel;
        }
    }
}
