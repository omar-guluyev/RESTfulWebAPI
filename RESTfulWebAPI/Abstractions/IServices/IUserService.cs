using RESTfulWebAPI.Entities.Identity;
using RESTfulWebAPI.Models;

namespace RESTfulWebAPI.Abstractions.IServices
{
    public interface IUserService
    {
        Task UpdateRefreshToken(string resreshToken, AppUser appUser, DateTime accessTokenDate);
        public Task<GenericResponseModel<bool>> AssignRoleToUserAsync(string userId, string[] roles);
        Task<GenericResponseModel<CreateUserResponseDTO>> CreateAsync(CreateUserDTO createUserDTO);
        public Task<GenericResponseModel<List<UserGetDTO>>> GetAllUsersAsync();
        public Task<GenericResponseModel<string[]>> GetRolesToUserAsync(string userIdOrName);
        public Task<GenericResponseModel<bool>> DeleteUserAsync(string userIdOrName);
        public Task<GenericResponseModel<bool>> UpdateeUserAsync(UserUpdateDTO userUpdateDTO);
    }

    public class CreateUserResponseDTO
    {
        public bool Succeded { get; set; }
        public string Message { get; set; }
    }

    public class CreateUserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UserGetDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class UserUpdateDTO
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
