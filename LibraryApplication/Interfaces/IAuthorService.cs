using LibraryApplication.DTO.Author;

namespace LibraryApplication.Service.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorGetDTO>> GetAllAuthors();
        Task<AuthorGetDTO> GetAuthorById(Guid id);
    }
}