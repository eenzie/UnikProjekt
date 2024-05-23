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

        async Task<IEnumerable<UserViewModel>?> IUserServiceProxy.GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserViewModel>>($"User");
        }

        async Task<UserViewModel?> IUserServiceProxy.GetUserById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<UserViewModel>($"User/{id}");
        }

        async Task<IEnumerable<UserViewModel>> IUserServiceProxy.GetUserByName(string name)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserViewModel>>($"User/{name}");
        }

        async Task<UserViewModel> IUserServiceProxy.CreateUser(CreateUserDto createUserDto)
        {
            var response = await _httpClient.PostAsJsonAsync("User/Create", createUserDto);

            //Exception
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UserViewModel>();
        }

        async Task<UserViewModel> IUserServiceProxy.EditUser(Guid id, UserViewModel updatedUser)
        {
            var response = await _httpClient.PutAsJsonAsync("User/Edit", updatedUser);

            //Exception
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UserViewModel>();

        }

        //    public async Task<IEnumerable<UserViewModel>?> GetAllUsers()
        //    {
        //        return await _httpClient.GetFromJsonAsync<IEnumerable<UserViewModel>>($"user/");

        //        //var result = new List<UserViewModel>();

            return await response.Content.ReadFromJsonAsync<DocumentViewModel>();
        }

        async Task<UserRoleViewModel> IUserServiceProxy.CreateUserRoleAsync(CreateUserRoleDto createUserRoleDto)
        {
            var response = await _httpClient.PostAsJsonAsync("UserRole/Create", createUserRoleDto);

            //Exception
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UserRoleViewModel>();
        }
    }
}