using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public class UserRoleServiceProxy : IUserRoleServiceProxy
    {
        private readonly HttpClient _httpClient;

        public UserRoleServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        async Task<RoleDto> IUserRoleServiceProxy.CreateUserRoleAsync(CreateUserRoleDto createUserRoleDto)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync("UserRole", createUserRoleDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<RoleDto>();
            }
            else
            {
                throw new Exception("Failed to create user role");
            }
        }

        async Task<IEnumerable<RoleDto>> IUserRoleServiceProxy.GetAllRolesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<RoleDto>>("Role");
        }
    }
}
