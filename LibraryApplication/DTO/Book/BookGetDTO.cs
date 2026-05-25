using LibraryApplication.DTO.BookAuthor;
using LibraryDomain.Entities;

namespace LibraryApplication.DTO.Book
{
    public class BookGetDTO
    {
      
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; } 
        public List<BookAuthorDTO> BookAuthors { get; set; } = [];
    }
}