using LibraryApplication.DTO.Book;
using LibraryApplication.DTO.BookAuthor;
using LibraryApplication.Exceptions;
using LibraryApplication.Service.Interfaces;
using LibraryDomain.Interfaces;

namespace LibraryApplication.Services
{
    public class BookServices : IBookService
    {
        private readonly IBookRepository _bookRepository;
 
        public BookServices(IBookRepository bookRepository, ICategoryRepository categoryRepository, IUserRepository userRepository, ILoanRepository loanRepository)
        {
            _bookRepository = bookRepository;
 
        }

        public async Task<List<BookGetDTO>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            var allBooks = new List<BookGetDTO>();
            foreach (var book in books)            {
                var bookDTO = new BookGetDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    BookAuthors =  new List<BookAuthorDTO>().ConvertAll(ba => new BookAuthorDTO
                    {
                        BookId = ba.BookId,
                        AuthorId = ba.AuthorId,
                        Author = new DTO.Author.AuthorGetDTO
                        {
                            Id = ba.Author.Id,
                            Name = ba.Author.Name, 
                        }
                    }),
                    PublicationYear = book.PublicationYear,
                    CategoryId = book.CategoryId,
                    Quantity = book.Quantity
                };
                allBooks.Add(bookDTO);
            }
            return  allBooks;
        }

        public async Task<BookGetDTO> GetBookById(Guid id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
            {
                throw new NotFoundException($"Book not found.");
            }
      
            var bookDTO = new BookGetDTO
            {
                Id = book.Id,
                Title = book.Title,
                BookAuthors = new List<BookAuthorDTO>().ConvertAll(ba => new BookAuthorDTO
                {
                    BookId = ba.BookId,
                    AuthorId = ba.AuthorId,
                    Author = new DTO.Author.AuthorGetDTO
                    {
                        Id = ba.Author.Id,
                        Name = ba.Author.Name, 
                    }
                }),
                PublicationYear = book.PublicationYear,
                CategoryId = book.CategoryId,
                Quantity = book.Quantity
            };
            return bookDTO;
        }
    }
}
