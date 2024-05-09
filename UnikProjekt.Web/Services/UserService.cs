using Newtonsoft.Json;
using RestSharp;
using UnikProjekt.Web.Models;

namespace UnikProjekt.Web.Services
{
    public class UserService
    {
        public List<UserViewModel> GetAllUsers()
        {
            var result = new List<UserViewModel>();

            var client = new RestClient("http://localhost:5062");
            var request = new RestRequest("/User", Method.Get);
            RestResponse response = client.Execute(request);
            var stringResponse = response.Content;

            var users = JsonConvert.DeserializeObject<List<UserViewModel>>(stringResponse);

            result.AddRange(users);


            //var options = new RestClientOptions("http://localhost:5062")
            //{
            //    MaxTimeout = -1,
            //};
            //var client = new RestClient(options);
            //var request = new RestRequest("/User", Method.Get);
            //RestResponse response = client.Execute(request);


            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    var stringResponse = response.Content;


            //    if (!string.IsNullOrWhiteSpace(stringResponse))
            //    {
            //        var users = JsonConvert.DeserializeObject<List<UserViewModel>>(stringResponse);

            //        result.AddRange(users);
            //    }
            //    else
            //    {
            //        return result.ToList();
            //    }
            //}
            //else
            //{
            //    // Hvis anmodningen mislykkedes, kast en exception eller håndter fejlen på anden vis
            //    throw new Exception($"Failed to get users. Status code: {response.StatusCode}");
            //}

            return result;

        }

        public UserViewModel GetUserById(string id)
        {
            var client = new RestClient("http://localhost:5062");
            var request = new RestRequest($"/User/ById/{id}", Method.Get);
            RestResponse response = client.Execute(request);
            var stringResponse = response.Content;

            var user = JsonConvert.DeserializeObject<UserViewModel>(stringResponse);

            return user;


            //var options = new RestClientOptions("http://localhost:5062")
            //{
            //    MaxTimeout = -1,
            //};
            //var client = new RestClient(options);
            //var request = new RestRequest($"/User/ById/{id}", Method.Get);
            //RestResponse response = client.Execute(request);

            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    var stringResponse = response.Content;

            //    var user = JsonConvert.DeserializeObject<UserViewModel>(stringResponse);

            //    return user;
            //}
            //else
            //{
            //    throw new Exception($"Failed to get user with ID {id}. Status code: {response.StatusCode}");
            //}
        }
    }
}
