using Newtonsoft.Json;
using RestSharp;
using System.Net;
using UnikProjekt.Web.Models;

namespace UnikProjekt.Web.Services
{
    public class UserService
    {
        public List<UserViewModel> GetAllUsers()
        {
            var result = new List<UserViewModel>();

            var options = new RestClientOptions("https://localhost:7150")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("https://localhost:7150/User", Method.Get);
            RestResponse response = client.Execute(request);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringResponse = response.Content;


                if (!string.IsNullOrWhiteSpace(stringResponse))
                {
                    var users = JsonConvert.DeserializeObject<List<UserViewModel>>(stringResponse);

                    result.AddRange(users);
                }
                else
                {
                    return result.ToList();
                }
            }
            else
            {
                // Hvis anmodningen mislykkedes, kast en exception eller håndter fejlen på anden vis
                throw new Exception($"Failed to get users. Status code: {response.StatusCode}");
            }

            return result;

        }

        public UserViewModel GetUserById(int id)
        {
            var options = new RestClientOptions("https://localhost:7150")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest($"https://localhost:7150/User/{id}", Method.Get);
            RestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringResponse = response.Content;

                var user = JsonConvert.DeserializeObject<UserViewModel>(stringResponse);

                return user;
            }
            else
            {
                throw new Exception($"Failed to get user with ID {id}. Status code: {response.StatusCode}");
            }
        }
    }
}
