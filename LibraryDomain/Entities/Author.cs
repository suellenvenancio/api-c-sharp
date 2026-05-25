namespace LibraryDomain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BookAuthor> BookAuthors { get; set; } = [];
    }
}