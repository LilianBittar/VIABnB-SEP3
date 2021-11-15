namespace DefaultNamespace
{
    public interface IAuthenticationService
    {
        Task<Host> Login(string email, string password);
    }
}