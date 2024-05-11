﻿using Newtonsoft.Json;
using RestSharp;
using System.Net;
using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.Services
{
    public class UserService
    {
        public List<UserViewModel> GetAllUsers()
        {
            var result = new List<UserViewModel>();

            var options = new RestClientOptions("http://localhost:5062")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/User", Method.Get);
            RestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringResponse = response.Content;

                var users = JsonConvert.DeserializeObject<List<UserViewModel>>(stringResponse);

                result.AddRange(users);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception($"Status code: {response.StatusCode}: Users was not found.");
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new Exception($"Status code: {response.StatusCode}: The request is invalid.");
            }
            else
            {
                throw new Exception($"Status code: {response.StatusCode}: Failed to get users.");
            }

            return result;
        }

        public UserViewModel GetUserById(string id)
        {
            var client = new RestClient("http://localhost:5062");
            var request = new RestRequest($"/User/{id}", Method.Get);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var stringResponse = response.Content;
                var user = JsonConvert.DeserializeObject<UserViewModel>(stringResponse);
                return user;
            }
            else
            {
                throw new Exception($"Status code: {response.StatusCode} Failed to get user with ID {id}.");
            }
        }

        public UserViewModel GetUserByName(string name)
        {

            var options = new RestClientOptions("http://localhost:5062")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest($"/User/{name}", Method.Get);
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var stringResponse = response.Content;
                var user = JsonConvert.DeserializeObject<UserViewModel>(stringResponse);
                return user;
            }
            else
            {
                throw new Exception($"Status code: {response.StatusCode} Failed to get user by name {name}.");
            }
        }

        public void CreateUser(CreateUserDto createUserDto)
        {
            //var options = new RestClientOptions("http://localhost:5062")
            //{
            //    MaxTimeout = -1,
            //};
            //var client = new RestClient(options);
            //var request = new RestRequest("/User/Create", Method.Post);
            //request.AddHeader("Content-Type", "application/json");
            //var body = JsonConvert.SerializeObject(new { createUserDto });
            //request.AddStringBody(body, DataFormat.Json);
            //RestResponse response = client.Execute(request);

            //var stringResponse = response.Content;

            //try
            //{
            //    var options = new RestClientOptions("http://localhost:5062")
            //    {
            //        MaxTimeout = -1,
            //    };
            //    var client = new RestClient(options);
            //    var request = new RestRequest("/User/Create", Method.Post);
            //    request.AddHeader("Content-Type", "application/json");

            //    var body = JsonConvert.SerializeObject(createUserDto);
            //    request.AddStringBody(body, DataFormat.Json);

            //    var response = client.Execute(request);

            //    if (response.IsSuccessful)
            //    {
            //        var stringResponse = response.Content;
            //    }
            //    else
            //    {
            //        var errorMessage = $"Error creating user: {response.ErrorMessage}";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    var errorMessage = $"An unexpected error occurred: {ex.Message}";
            //}

            try
            {
                var options = new RestClientOptions("http://localhost:5062")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/User/Create", Method.Post);
                request.AddHeader("Content-Type", "application/json");

                var body = JsonConvert.SerializeObject(createUserDto);
                request.AddStringBody(body, DataFormat.Json);

                var response = client.Execute(request);
                //jeg tester ... 
                Console.WriteLine("After API call.");

                if (response.IsSuccessful)
                {
                    var successMessage = "User created successfully!";
                    Console.WriteLine(successMessage);
                }
                else
                {
                    var errorMessage = $"Error creating user. StatusCode: {response.StatusCode}, Content: {response.Content}";
                    Console.WriteLine(errorMessage);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred: {ex.Message}";
                Console.WriteLine(errorMessage);
            }


            //TODO: Anh popup message for response content
        }
    }
}
