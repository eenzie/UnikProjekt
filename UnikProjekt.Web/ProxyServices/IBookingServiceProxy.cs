using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public interface IBookingServiceProxy
    {
        Task<IEnumerable<BookingDto>?> GetAllBookingsAsync();
        Task<BookingDto?> GetBookingByIdAsync(Guid id);
        Task<IEnumerable<BookingDto>> GetBookingByNameAsync(string name);
        Task<BookingDto> CreateBookingAsync(CreateBookingDto createBookingDto);
        Task<BookingDto> EditBookingAsync(EditBookingDto editBookingDto);

        Task<IEnumerable<BookingItemDto>?> GetAllBookingItemsAsync();
        Task<BookingItemDto?> GetBookingItemByIdAsync(Guid id);
        Task<IEnumerable<BookingItemDto>> GetBookingItemByNameAsync(string name);
        Task<BookingItemDto> CreateBookingItemAsync(CreateBookingItemDto createBookingItemDto);
        Task<BookingItemDto> EditBookingItemAsync(EditBookingItemDto editBookingItemDto);




    }
}
