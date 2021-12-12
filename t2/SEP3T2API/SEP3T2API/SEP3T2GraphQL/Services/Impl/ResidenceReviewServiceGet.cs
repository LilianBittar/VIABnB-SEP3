using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class ResidenceReviewService : IResidenceReviewService
    {
       
        
        public Task<IEnumerable<ResidenceReview>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
            
        public async Task<IEnumerable<ResidenceReview>> GetAllByResidenceIdAsync(int residenceId)
        {
            if (residenceId!=0)
            {
                return await _residenceReviewRepository.GetAllResidenceReviewByResidenceIdAsync(residenceId);
            }

            throw new ArgumentException("residenceId required");
        }
    }
}