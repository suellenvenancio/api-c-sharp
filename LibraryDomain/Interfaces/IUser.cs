using LibraryDomain.Entities;

namespace LibraryDomain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid id);
    }
}