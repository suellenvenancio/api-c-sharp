namespace LibraryDomain.Entities
{
    public class Book
    {

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<BookAuthor> BookAuthors { get; set; } = [];
    }
}