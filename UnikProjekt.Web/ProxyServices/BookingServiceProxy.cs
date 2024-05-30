using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public class BookingServiceProxy : IBookingServiceProxy
    {
        private readonly HttpClient _httpClient;

        public BookingServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<IEnumerable<BookingDto>?> IBookingServiceProxy.GetAllBookingsAsync()
        {
            var httpResponseMessage = await _httpClient.GetFromJsonAsync<IEnumerable<BookingDto>>("Booking");
            return httpResponseMessage;
        }

        async Task<BookingDto?> IBookingServiceProxy.GetBookingByIdAsync(Guid id)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"Booking/ById{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<BookingDto>();
            }
            else
            {
                throw new Exception("Failed to get booking by id");
            }
        }

        async Task<IEnumerable<BookingDto>> IBookingServiceProxy.GetBookingByNameAsync(string name)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"Booking/ByUser{name}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<BookingDto>>();
            }
            else
            {
                throw new Exception("Failed to get booking by name");
            }
        }

        async Task<BookingDto> IBookingServiceProxy.CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync("Booking", createBookingDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<BookingDto>();
            }
            else
            {
                throw new Exception("Failed to create booking");
            }

        }

        async Task<BookingDto> IBookingServiceProxy.EditBookingAsync(EditBookingDto editBookingDto)
        {
            var httpResponseMessage = await _httpClient.PutAsJsonAsync($"Booking", editBookingDto);
            httpResponseMessage.EnsureSuccessStatusCode();
            return await httpResponseMessage.Content.ReadFromJsonAsync<BookingDto>();
        }

        async Task<IEnumerable<BookingItemDto>?> IBookingServiceProxy.GetAllBookingItemsAsync()
        {
            var httpResponseMessage = await _httpClient.GetFromJsonAsync<IEnumerable<BookingItemDto>>("BookingItem");
            return httpResponseMessage;
        }

        async Task<BookingItemDto?> IBookingServiceProxy.GetBookingItemByIdAsync(Guid id)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"BookingItem/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<BookingItemDto>();
            }
            else
            {
                throw new Exception("Failed to get booking item by id");
            }
        }

        async Task<IEnumerable<BookingItemDto>> IBookingServiceProxy.GetBookingItemByNameAsync(string name)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"BookingItem/{name}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<BookingItemDto>>();
            }
            else
            {
                throw new Exception("Failed to get booking item by name");
            }
        }

        async Task<BookingItemDto> IBookingServiceProxy.CreateBookingItemAsync(CreateBookingItemDto createBookingItemDto)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync("BookingItem", createBookingItemDto);
            httpResponseMessage.EnsureSuccessStatusCode();
            return await httpResponseMessage.Content.ReadFromJsonAsync<BookingItemDto>();
        }

        async Task<BookingItemDto> IBookingServiceProxy.EditBookingItemAsync(EditBookingItemDto editBookingItemDto)
        {
            var httpResponseMessage = await _httpClient.PutAsJsonAsync($"BookingItem", editBookingItemDto);
            httpResponseMessage.EnsureSuccessStatusCode();
            return await httpResponseMessage.Content.ReadFromJsonAsync<BookingItemDto>();
        }
    }
}
