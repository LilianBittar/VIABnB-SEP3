using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Repositories.Administration;

namespace SEP3T2GraphQL.Services.Impl
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IAdministrationRepository _administrationRepository;
        private IHostRepository _hostRepository;
        private IGuestRepository _guestRepository;

        public UserService(IUserRepository userRepository, IAdministrationRepository administrationRepository, IHostRepository hostRepository, IGuestRepository guestRepository)
        {
            _userRepository = userRepository;
            _administrationRepository = administrationRepository;
            _hostRepository = hostRepository;
            _guestRepository = guestRepository;
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

        public Task<User> ValidateUserAsync(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}