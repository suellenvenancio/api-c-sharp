using LibraryDomain.Entities;

namespace LibraryDomain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);
        Task CreateUser(User user);
    }
}