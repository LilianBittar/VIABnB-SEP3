using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateResidenceReviewValidator
    {
        private readonly IResidenceService _residenceService;
        private readonly IRentRequestRepository _rentRequestRepository;

        public CreateResidenceReviewValidator(IResidenceService residenceService, IRentRequestRepository rentRequestRepository)
        {
            _residenceService = residenceService;
            _rentRequestRepository = rentRequestRepository;
        }

        public void ValidateResidenceReview(ResidenceReview residenceReview)
        {
            
        }
    }
}