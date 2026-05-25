using LibraryApplication.DTO.Author;
using LibraryApplication.DTO.Book;

namespace LibraryApplication.DTO.BookAuthor
{
    public class BookAuthorDTO
    {
        public Guid BookId { get; set; }
        public BookGetDTO? Book { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorGetDTO? Author { get; set; }
    }
}