using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.ProxyServices;

namespace UnikProjekt.Web.Services
{
    public class UserService : IUserServiceProxy
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<IEnumerable<UserViewModel>?> IUserServiceProxy.GetAllUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserViewModel>>($"User");
        }

        async Task<UserViewModel?> IUserServiceProxy.GetUserByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<UserViewModel>($"User/{id}");
        }

        async Task<IEnumerable<UserViewModel>> IUserServiceProxy.GetUserByNameAsync(string name)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserViewModel>>($"User/{name}");
        }

        async Task<UserViewModel> IUserServiceProxy.CreateUserAsync(CreateUserDto createUserDto)
        {
            var response = await _httpClient.PostAsJsonAsync("User/Create", createUserDto);

            //Exception
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UserViewModel>();
        }

        async Task<UserViewModel> IUserServiceProxy.EditUserAsync(Guid id, UserViewModel updatedUser)
        {
            var response = await _httpClient.PutAsJsonAsync("User/Edit", updatedUser);

            //Exception
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UserViewModel>();

        }

        async Task<DocumentViewModel> IUserServiceProxy.CreateDocumentAsync(CreateDocumentDto createDocumentDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Document/Create", createDocumentDto);

            //Exception
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<DocumentViewModel>();
        }
    }
}