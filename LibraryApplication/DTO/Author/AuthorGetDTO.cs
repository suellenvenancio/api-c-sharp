using LibraryApplication.DTO.BookAuthor;

namespace LibraryApplication.DTO.Author
{
    public class AuthorGetDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public  List<BookAuthorDTO> BookAuthors { get; set; }
    }
}