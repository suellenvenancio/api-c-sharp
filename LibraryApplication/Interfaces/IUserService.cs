using LibraryApplication.DTO.User;

namespace LibraryApplication.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserGetDTO> GetUserById(Guid id);
        Task<UserGetDTO> CreateUser(UserPostDTO userPostDTO);
        Task<string> Login(string email, string password);
    }
}