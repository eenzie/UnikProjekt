using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public class UserServiceProxy : IUserServiceProxy
    {
        private readonly HttpClient _httpClient;

        public UserServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<IEnumerable<UserDto>?> IUserServiceProxy.GetAllUsersAsync()
        {
            var httpResponseMessage = await _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>("User");
            return httpResponseMessage;
        }


        async Task<UserDto?> IUserServiceProxy.GetUserByIdAsync(Guid id)
        {

            var httpResponseMessage = await _httpClient.GetAsync($"User/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<UserDto>();
            }
            else
            {
                Console.WriteLine($"Error: {httpResponseMessage.StatusCode}");
                return null;
            }

        }

        async Task<IEnumerable<UserDto>> IUserServiceProxy.GetUserByNameAsync(string name)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"User/{name}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
            }
            else
            {
                Console.WriteLine($"Error: {httpResponseMessage.StatusCode}");
                return null;
            }
        }

        async Task<UserDto> IUserServiceProxy.CreateUserAsync(CreateUserDto createUserDto)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync("User", createUserDto);
            httpResponseMessage.EnsureSuccessStatusCode();
            return await httpResponseMessage.Content.ReadFromJsonAsync<UserDto>();
        }

        async Task<UserDto> IUserServiceProxy.EditUserAsync(Guid id, EditUserDto editUserDto)
        {
            var httpResponseMessage = await _httpClient.PutAsJsonAsync($"User/{id}", editUserDto);
            httpResponseMessage.EnsureSuccessStatusCode();
            return await httpResponseMessage.Content.ReadFromJsonAsync<UserDto>();
        }

    }
}




