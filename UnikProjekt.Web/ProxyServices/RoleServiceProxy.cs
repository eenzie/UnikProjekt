using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public class RoleServiceProxy : IRoleServiceProxy
    {
        private readonly HttpClient _httpClient;

        public RoleServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<IEnumerable<RoleDto>?> IRoleServiceProxy.GetAllRolesAsync()
        {
            var httpResponseMessage = await _httpClient.GetFromJsonAsync<IEnumerable<RoleDto>>("Role");
            return httpResponseMessage;
        }

        async Task<RoleDto> IRoleServiceProxy.GetRoleByIdAsync(Guid id)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"Role/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<RoleDto>();
            }
            else
            {
                throw new Exception("Failed to get role by id");
            }
        }

        async Task<IEnumerable<RoleDto>> IRoleServiceProxy.GetRoleByNameAsync(string name)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"Role/{name}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RoleDto>>();
            }
            else
            {
                throw new Exception("Failed to get role by name");
            }
        }

        async Task<RoleDto> IRoleServiceProxy.CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync("Role", createRoleDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<RoleDto>();
            }
            else
            {
                throw new Exception("Failed to create role");
            }
        }

        async Task<RoleDto> IRoleServiceProxy.EditRoleAsync(Guid id, EditRoleDto editRoleDto)
        {
            var httpResponseMessage = await _httpClient.PutAsJsonAsync($"Role/{id}", editRoleDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<RoleDto>();
            }
            else
            {
                throw new Exception("Failed to update role");
            }
        }
    }
}
