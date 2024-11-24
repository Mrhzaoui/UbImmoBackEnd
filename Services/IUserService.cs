using UBEE.Models;

namespace UBEE.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<(bool Succeeded, string[] Errors)> RegisterUser(UserRegistrationDto model);
        Task<(bool Succeeded, string Token)> LoginUser(UserLoginDto model);
        Task<(bool Succeeded, string[] Errors)> UpdateUser(int id, UserUpdateDto model);
        Task<(bool Succeeded, string[] Errors)> DeleteUser(int id);
    }
}

