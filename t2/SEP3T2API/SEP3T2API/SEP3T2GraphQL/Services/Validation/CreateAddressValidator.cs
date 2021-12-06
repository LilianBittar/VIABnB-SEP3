using System;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateAddressValidator
    {
        private readonly IAddressRepository _addressRepository;

        public CreateAddressValidator(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void ValidateAddress(Address address)
        {
            if (address == null)
            {
                throw new ArgumentException("Address is required");
            }
            //TODO: implement this. 
        }
        
    }
}