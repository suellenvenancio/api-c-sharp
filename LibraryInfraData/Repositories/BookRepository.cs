using LibraryDomain.Entities;
using LibraryDomain.Interfaces;

namespace LibraryInfraData.Repositories {
    public class BookRepository : IBookRepository
    {
        public Task<List<Book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookById(int id)
        {
            throw new NotImplementedException();
        }
    }

}