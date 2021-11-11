namespace SEP3T2GraphQL.Repositories
{
    public interface IGuestRegistrationRequestRepository
    {
          Task<GuestRegistrationRequest> CreateGuestRegistrationRequest(GuestRegistrationRequest guestRegistrationRequest); 
        Task<IEnumerable<GuestRegistrationRequest>> GetAllGuestRegistrationRequests();
        Task<GuestRegistrationRequest> ApproveGusetRegistrationRequset(int requestId); 
        Task<GuestRegistrationRequest> RejectGusetRegistrationRequset(int requestId); 

    }
}