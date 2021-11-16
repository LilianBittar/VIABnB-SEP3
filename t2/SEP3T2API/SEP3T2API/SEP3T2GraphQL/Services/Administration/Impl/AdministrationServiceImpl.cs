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
        private IAdminValidation _adminValidation;

        public AdministrationServiceImpl(IAdministrationRepository administrationRepository)
        {
            _administrationRepository = administrationRepository;
            _adminValidation = new AdminValidationImpl();
        }
    }
}