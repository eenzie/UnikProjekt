using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.ProxyServices;

namespace UnikProjekt.Web.Services
{
    public class UserService
    {
        private readonly IUserServiceProxy _userServiceProxy;

        public UserService(IUserServiceProxy userServiceProxy)
        {
            _userServiceProxy = userServiceProxy;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            var userDtos = await _userServiceProxy.GetAllUsersAsync();
            if (userDtos == null)
            {
                return null;
            }

            var userViewModels = userDtos.Select(userDto => new UserViewModel
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                MobileNumber = userDto.MobileNumber,
                Street = userDto.Street,
                StreetNumber = userDto.StreetNumber,
                PostCode = userDto.PostCode,
                City = userDto.City,
            });

            return userViewModels;
        }

        public async Task<UserViewModel> GetUserByIdAsync(Guid id)
        {
            var userDto = await _userServiceProxy.GetUserByIdAsync(id);
            if (userDto == null)
            {
                return null;
            }
            return new UserViewModel
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                MobileNumber = userDto.MobileNumber,
                Street = userDto.Street,
                StreetNumber = userDto.StreetNumber,
                PostCode = userDto.PostCode,
                City = userDto.City,
                RowVersion = userDto.RowVersion
            };
        }

        public async Task<IEnumerable<UserViewModel>> GetUserByNameAsync(string name)
        {
            var userDto = await _userServiceProxy.GetUserByNameAsync(name);
            return userDto.Select(userDto => new UserViewModel
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                MobileNumber = userDto.MobileNumber,
                Street = userDto.Street,
                StreetNumber = userDto.StreetNumber,
                PostCode = userDto.PostCode,
                City = userDto.City,
            });
        }

        public async Task<Guid> CreateUserAsync(CreateUserDto createUserDto)
        {
            var userDto = await _userServiceProxy.CreateUserAsync(createUserDto);
            if (userDto == null)
            {
                return Guid.Empty;
            }

            return userDto.Id;
        }


        public async Task<Guid> EditUserAsync(Guid id, EditUserDto editUserDto)
        {
            var editedUserDto = await _userServiceProxy.EditUserAsync(editUserDto);
            if (editedUserDto == null)
            {
                return Guid.Empty;
            }
            return editedUserDto.Id;

        }
    }
}
