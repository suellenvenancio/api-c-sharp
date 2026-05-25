using LibraryDomain.Entities;

namespace LibraryDomain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> GetAuthorById(Guid id);
        Task<List<Author>> GetAllAuthors();
    }
}