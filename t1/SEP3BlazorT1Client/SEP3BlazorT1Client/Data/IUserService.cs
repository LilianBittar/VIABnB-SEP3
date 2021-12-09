using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> ValidateUserAsync(string email, string password);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(User user);
    }
}