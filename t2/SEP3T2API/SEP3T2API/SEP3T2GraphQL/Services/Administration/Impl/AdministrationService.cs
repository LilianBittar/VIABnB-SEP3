using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories.Administration;

namespace SEP3T2GraphQL.Services.Administration.Impl
{
    public class AdministrationService : IAdministrationService
    {
        private readonly IAdministrationRepository _administrationRepository;
        public AdministrationService(IAdministrationRepository administrationRepository)
        {
            _administrationRepository = administrationRepository;
        }

        public async Task<Administrator> GetAdminByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Invalid email");
            }
            var administratorToReturn = await _administrationRepository.GetAdminByEmailAsync(email);
            return administratorToReturn;
        }

        public async Task<IEnumerable<Administrator>> GetAllAdmins()
        {
            var administratorsToReturn = await _administrationRepository.GetAllAdminsAsync();
            if (administratorsToReturn == null)
            {
                throw new Exception("Admin list cant be null");
            }

            return administratorsToReturn;
        }

        public async Task<Administrator> ValidateAdmin(string email, string password)
        {
            var adminToValidate = await GetAdminByEmail(email);
            if (adminToValidate == null)
            {
                throw new ArgumentException("No admin with email matching the given email");
            }

            if (adminToValidate.Password != password)
            {
                throw new ArgumentException("The given password is incorrect");
            }

            return adminToValidate;
        }
    }
}