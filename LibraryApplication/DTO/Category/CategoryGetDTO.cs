namespace LibraryApplication.DTO.Category
{
    public class CategoryGetDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Book.BookGetDTO> Books { get; set; } = [];
    }
}