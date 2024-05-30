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
                throw new Exception("Failed to get user by id");
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
                throw new Exception("Failed to get user by name");
            }
        }

        async Task<UserDto> IUserServiceProxy.CreateUserAsync(CreateUserDto createUserDto)
        {
            try
            {
                var httpResponseMessage = await _httpClient.PostAsJsonAsync("User", createUserDto);
                httpResponseMessage.EnsureSuccessStatusCode();
                return await httpResponseMessage.Content.ReadFromJsonAsync<UserDto>();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create user");

            }
        }

        async Task<UserDto> IUserServiceProxy.EditUserAsync(EditUserDto editUserDto)
        {
            try
            {
                var httpResponseMessage = await _httpClient.PutAsJsonAsync($"User", editUserDto);
                httpResponseMessage.EnsureSuccessStatusCode();
                return await httpResponseMessage.Content.ReadFromJsonAsync<UserDto>();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to edit user");

            }
        }

    }
}




