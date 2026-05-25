using LibraryApplication.DTO.Author;
using LibraryApplication.Exceptions;
using LibraryApplication.Service.Interfaces;
using LibraryDomain.Interfaces;

namespace LibraryApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<AuthorGetDTO>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAllAuthors();

            var allAuthors = new List<AuthorGetDTO>();
            foreach (var author in authors)            {
                var authorDTO = new AuthorGetDTO
                {
                    Id = author.Id,
                    Name = author.Name,
                 };
                allAuthors.Add(authorDTO);  
            }
            return allAuthors;
        }

        public async Task<AuthorGetDTO> GetAuthorById(Guid id)
        {
            var author = await _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                throw new NotFoundException($"Author not found.");
            }
            return new AuthorGetDTO
            {
                Id = author.Id,
                Name = author.Name,
            };
        }
    }
}