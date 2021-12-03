using System.Net.Http;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class ResidenceReviewService : IResidenceReviewService
    {
        private readonly IResidenceService _residenceService;

        public ResidenceReviewService(IResidenceService residenceService)
        {
            _residenceService = residenceService;
        }

        public Task<ResidenceReview> CreateAsync(Residence residence, ResidenceReview residenceReview)
        {
            throw new System.NotImplementedException();
        }
    }
}