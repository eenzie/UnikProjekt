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

        //        //var options = new RestClientOptions("http://localhost:5062")
        //        //{
        //        //    MaxTimeout = -1,
        //        //};
        //        //var client = new RestClient(options);
        //        //var request = new RestRequest("/User", Method.Get);
        //        //RestResponse response = client.Execute(request);

        //        //if (response.StatusCode == HttpStatusCode.OK)
        //        //{
        //        //    var stringResponse = response.Content;

        //        //    var users = JsonConvert.DeserializeObject<List<UserViewModel>>(stringResponse);

        //        //    result.AddRange(users);
        //        //}
        //        //else if (response.StatusCode == HttpStatusCode.NotFound)
        //        //{
        //        //    throw new Exception($"Status code: {response.StatusCode}: Users was not found.");
        //        //}
        //        //else if (response.StatusCode == HttpStatusCode.BadRequest)
        //        //{
        //        //    throw new Exception($"Status code: {response.StatusCode}: The request is invalid.");
        //        //}
        //        //else
        //        //{
        //        //    throw new Exception($"Status code: {response.StatusCode}: Failed to get users.");
        //        //}

        //        //return result;
        //    }

        //    public UserViewModel GetUserById(Guid id)
        //    {
        //        var options = new RestClientOptions("http://localhost:5062")
        //        {
        //            MaxTimeout = -1,
        //        };


        //        var client = new RestClient(options);
        //        var request = new RestRequest($"/User/{id}", Method.Get);


        //        var response = client.Execute(request);

        //        if (response.IsSuccessful)
        //        {
        //            var stringResponse = response.Content;

        //            try
        //            {
        //                return JsonConvert.DeserializeObject<UserViewModel>(stringResponse);
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"Deserialization error: {ex.Message}");
        //                throw;
        //            }
        //        }

        //        if (response.StatusCode == HttpStatusCode.NotFound)
        //        {
        //            return null;
        //        }

        //        throw new Exception($"Status code: {response.StatusCode} Failed to get user with");
        //    }

        //    public List<UserViewModel> GetUserByName(string name)
        //    {

        //        var options = new RestClientOptions("http://localhost:5062")
        //        {
        //            MaxTimeout = -1,
        //        };
        //        var client = new RestClient(options);
        //        var request = new RestRequest($"/User/{name}", Method.Get);
        //        RestResponse response = client.Execute(request);

        //        if (response.IsSuccessful)
        //        {
        //            var stringResponse = response.Content;
        //            var user = JsonConvert.DeserializeObject<List<UserViewModel>>(stringResponse);
        //            return user;
        //        }
        //        else
        //        {
        //            throw new Exception($"Status code: {response.StatusCode} Failed to get user by name {name}.");
        //        }
        //    }

        //    public UserViewModel CreateUser(CreateUserDto createUserDto)
        //    {
        //        var result = new UserViewModel();

        //        try
        //        {
        //            var options = new RestClientOptions("http://localhost:5062")
        //            {
        //                MaxTimeout = -1,
        //            };
        //            var client = new RestClient(options);
        //            var request = new RestRequest("/User", Method.Post);
        //            request.AddHeader("Content-Type", "application/json");

        //            var body = JsonConvert.SerializeObject(createUserDto);
        //            request.AddStringBody(body, DataFormat.Json);

        //            var response = client.Execute(request);

        //            if (response.IsSuccessful)
        //            {
        //                var stringResponse = response.Content;



        //                var successMessage = "User created successfully!";
        //                Console.WriteLine(successMessage);
        //                return result;

        //            }
        //            else
        //            {
        //                var errorMessage = $"Error creating user. StatusCode: {response.StatusCode}, Content: {response.Content}";
        //                Console.WriteLine(errorMessage);
        //                return null;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            var errorMessage = $"An unexpected error occurred: {ex.Message}";
        //            Console.WriteLine(errorMessage);
        //        }
        //        return null;

        //        //TODO: Anh required fields
        //    }


        //    public UserViewModel EditUser(Guid id, UserViewModel updatedUser)
        //    {
        //        //try
        //        //{
        //        //    var options = new RestClientOptions("http://localhost:5062")
        //        //    {
        //        //        MaxTimeout = -1,
        //        //    };
        //        //    var client = new RestClient(options);
        //        //    var request = new RestRequest($"/User/{id}", Method.Put);
        //        //    request.AddHeader("Content-Type", "application/json");
        //        //    var body = JsonConvert.SerializeObject(updatedUser);

        //        //    request.AddStringBody(body, DataFormat.Json);
        //        //    var response = client.Execute(request);

        //        //    if (response.IsSuccessful)
        //        //    {
        //        //        var stringResponse = response.Content;

        //        //        var successMessage = "User updated successfully!";
        //        //        Console.WriteLine(successMessage);
        //        //        return updatedUser;
        //        //    }
        //        //    else
        //        //    {
        //        //        var errorMessage = $"Error updating user. StatusCode: {response.StatusCode}, Content: {response.Content}";
        //        //        Console.WriteLine(errorMessage);
        //        //        return null;
        //        //    }
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    var errorMessage = $"An unexpected error occurred: {ex.Message}";
        //        //    Console.WriteLine(errorMessage);
        //        //    return null;
        //        //}

        //        try
        //        {
        //            var options = new RestClientOptions("http://localhost:5062")
        //            {
        //                MaxTimeout = -1,
        //            };
        //            var client = new RestClient(options);

        //            var request = new RestRequest("/users/edit", Method.Put);

        //            request.AddParameter("id", id);

        //            var body = JsonConvert.SerializeObject(updatedUser);

        //            request.AddParameter("application/json", body, ParameterType.RequestBody);

        //            var response = client.Execute(request);

        //            if (response.IsSuccessful)
        //            {
        //                var stringResponse = response.Content;
        //                var successMessage = "User updated successfully!";
        //                Console.WriteLine(successMessage);
        //                return updatedUser;
        //            }
        //            else
        //            {
        //                var errorMessage = $"Error updating user. StatusCode: {response.StatusCode}, Content: {response.Content}";
        //                Console.WriteLine(errorMessage);

        //                throw new Exception(errorMessage);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            var errorMessage = $"An unexpected error occurred: {ex.Message}";
        //            Console.WriteLine(errorMessage);

        //            throw new Exception(errorMessage);
        //        }
        //    }
        //}
    }
}