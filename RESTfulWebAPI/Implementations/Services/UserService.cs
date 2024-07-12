using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RESTfulWebAPI.Abstractions.IServices;
using RESTfulWebAPI.Entities.Identity;
using RESTfulWebAPI.Models;

namespace RESTfulWebAPI.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public Task<GenericResponseModel<bool>> AssignRoleToUserAsync(string userId, string[] roles)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericResponseModel<CreateUserResponseDTO>> CreateAsync(CreateUserDTO createUserDTO)
        {
            var response = new GenericResponseModel<CreateUserResponseDTO>();
            try
            {
                var id = Guid.NewGuid().ToString();
                if (createUserDTO == null)
                {
                    response.StatusCode = 404;
                    response.Data = null;
                }

                var mappedUser = mapper.Map<AppUser>(createUserDTO);
                var result = await userManager.CreateAsync(mappedUser, createUserDTO.Password);
                response.StatusCode = 200;
                response.Data = new CreateUserResponseDTO { Succeded = result.Succeeded };

                if (!result.Succeeded)
                {
                    response.StatusCode = 400;
                    response.Data.Message = string.Join(" \n ", result.Errors.Select(error => $"{error.Code} - {error.Description}"));
                }
                AppUser user = await userManager.FindByNameAsync(createUserDTO.Username);
                if (user == null)
                    user = await userManager.FindByEmailAsync(createUserDTO.Email);
                if (user == null)
                    user = await userManager.FindByIdAsync(id);
                if (user != null)
                    await userManager.AddToRoleAsync(user, "User");
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public Task<GenericResponseModel<bool>> DeleteUserAsync(string userIdOrName)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponseModel<List<UserGetDTO>>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponseModel<string[]>> GetRolesToUserAsync(string userIdOrName)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponseModel<bool>> UpdateeUserAsync(UserUpdateDTO userUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRefreshToken(string resreshToken, AppUser appUser, DateTime accessTokenDate)
        {
            throw new NotImplementedException();
        }
    }
}
