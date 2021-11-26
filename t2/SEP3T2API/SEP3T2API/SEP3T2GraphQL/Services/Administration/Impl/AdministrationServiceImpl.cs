using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories.Administration;
using SEP3T2GraphQL.Services.Validation.AdministrationValidation;
using SEP3T2GraphQL.Services.Validation.AdministrationValidation.Impl;

namespace SEP3T2GraphQL.Services.Administration.Impl
{
    public class AdministrationServiceImpl : IAdministrationService
    {
        private IAdministrationRepository _administrationRepository;
        public AdministrationServiceImpl(IAdministrationRepository administrationRepository)
        {
            _administrationRepository = administrationRepository;
        }

        public async Task<Administrator> GetAdminByEmail(string email)
        {
            var administratorToReturn = await _administrationRepository.GetAdminByEmail(email);
            if (administratorToReturn == null)
            {
                throw new Exception("Admin cant be null");
            }

            return administratorToReturn;
        }

        public async Task<IEnumerable<Administrator>> GetAllAdmins()
        {
            var administratorsToReturn = await _administrationRepository.GetAllAdmins();
            if (administratorsToReturn == null)
            {
                throw new Exception("Admin list cant be null");
            }

            return administratorsToReturn;
        }
    }
}