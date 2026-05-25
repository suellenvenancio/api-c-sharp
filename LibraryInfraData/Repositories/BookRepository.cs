using LibraryDomain.Entities;
using LibraryDomain.Interfaces;
using LibraryInfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryInfraData.Repositories {
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooks()
        {
          return await  _context.Book.ToListAsync();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _context.Book.FindAsync(id);
        }

   
    }

}