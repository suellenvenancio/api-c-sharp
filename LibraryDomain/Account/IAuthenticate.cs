using LibraryDomain.Entities;

namespace LibraryDomain.Account
{
    public interface IAuthenticate
    {
        string GenerateToken(Guid id, string email);
        Task<Boolean> Authenticate(string email, string password);
        Task<bool> UserExists(string email);
    }
}