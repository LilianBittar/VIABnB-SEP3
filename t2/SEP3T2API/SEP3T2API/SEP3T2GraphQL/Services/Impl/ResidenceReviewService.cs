using System.Net.Http;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class ResidenceReviewService : IResidenceReviewService
    {
        private readonly IResidenceService _residenceService;
        private readonly IResidenceReviewRepository _residenceReviewRepository;
        private readonly CreateResidenceReviewValidator _validator; 

        public ResidenceReviewService(IResidenceService residenceService, IResidenceReviewRepository residenceReviewRepository, CreateResidenceReviewValidator validator)
        {
            _residenceService = residenceService;
            _residenceReviewRepository = residenceReviewRepository;
            _validator = validator; 
        }
        public Task<ResidenceReview> CreateAsync(Residence residence, ResidenceReview residenceReview)
        {
            _validator.ValidateResidenceReview(residenceReview);
            
        }
    }
}