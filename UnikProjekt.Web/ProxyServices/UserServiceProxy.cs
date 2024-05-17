﻿using UnikProjekt.Web.Models;
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

        async Task<IEnumerable<UserViewModel>?> IUserServiceProxy.GetAllUsers()
        {
            var httpResponseMessage = await _httpClient
           .GetFromJsonAsync<IEnumerable<UserViewModel>>("User");
            return httpResponseMessage;
        }

        //async Task<UserViewModel> GetUserById(Guid id)
        //{
        //    var httpResponseMessage = await _httpClient
        //    .GetFromJsonAsync<UserViewModel>($"User/{id}");

        //    return httpResponseMessage;
        //}


        //async Task<UserViewModel> CreateUser(CreateUserDto createUserDto)
        //{
        //    var httpResponseMessage = await _httpClient.PostAsJsonAsync("User", createUserDto);
        //    return await httpResponseMessage.Content.ReadFromJsonAsync<UserViewModel>();

        //}

        //async Task<UserViewModel> UpdateUser(Guid id, UserViewModel updatedUser)
        //{
        //    var httpResponseMessage = await _httpClient.PutAsJsonAsync($"User/{id}", updatedUser);
        //    return await httpResponseMessage.Content.ReadFromJsonAsync<UserViewModel>();
        //}

        async Task<UserViewModel?> IUserServiceProxy.GetUserById(Guid id)
        {
            //var httpResponseMessage = await _httpClient
            //.GetFromJsonAsync<UserViewModel>($"User/{id}");

            //return httpResponseMessage;


            var httpResponseMessage = await _httpClient.GetAsync($"User/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<UserViewModel>();
            }
            else
            {
                Console.WriteLine($"An error occurred: {httpResponseMessage.StatusCode}");
                return null;
            }

        }

        async Task<IEnumerable<UserViewModel>> IUserServiceProxy.GetUserByName(string name)
        {
            //  var httpResponseMessage = await _httpClient
            //.GetFromJsonAsync<IEnumerable<UserViewModel>>($"User/{name}");
            //  return httpResponseMessage;

            var httpResponseMessage = await _httpClient.GetAsync($"User/{name}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<UserViewModel>>();
            }
            else
            {
                Console.WriteLine($"An error occurred: {httpResponseMessage.StatusCode}");
                return null;
            }
        }

        async Task<UserViewModel> IUserServiceProxy.CreateUser(CreateUserDto createUserDto)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync("User", createUserDto);
            return await httpResponseMessage.Content.ReadFromJsonAsync<UserViewModel>();
        }

        async Task<UserViewModel> IUserServiceProxy.EditUser(Guid id, UserViewModel updatedUser)
        {
            var httpResponseMessage = await _httpClient.PutAsJsonAsync($"User/{id}", updatedUser);
            return await httpResponseMessage.Content.ReadFromJsonAsync<UserViewModel>();
        }
    }
}
