using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Repositories.Administration;
using SEP3T2GraphQL.Services.Administration;

namespace SEP3T2GraphQL.Services.Impl
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IAdministrationService _administrationService;
        private IHostService _hostService;
        private IGuestService _guestService;

        public UserService(IUserRepository userRepository, IAdministrationService administrationService, IHostService hostService, IGuestService guestService)
        {
            _userRepository = userRepository;
            _administrationService = administrationService;
            _hostService = hostService;
            _guestService = guestService;
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _userRepository.GetUserByEmailAsync(email);
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return _userRepository.GetUserByIdAsync(id);
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return _userRepository.GetAllUsersAsync();
        }

        public async Task<User> ValidateUserAsync(string email, string password)
        {
            try
            {
                var user = await GetUserByEmailAsync(email);
                if (user == null)
                {
                    throw new ArgumentException("User not found");
                }

                if (user.Password != password)
                {
                    throw new ArgumentException("Incorrect password");
                }

                return user;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                return await _userRepository.UpdateUserAsync(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteUserSync(int userId)
        {
            try
            {
                await _userRepository.DeleteUserAsync(userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}