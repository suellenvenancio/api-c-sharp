using LibraryDomain.Entities;
using LibraryDomain.Interfaces;
using LibraryInfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryInfraData.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            return await _context.Author.ToListAsync();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            return await _context.Author.FindAsync(id);
        }
    }

}