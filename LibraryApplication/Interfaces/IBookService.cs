using LibraryApplication.DTO.Book;
 
namespace LibraryApplication.Service.Interfaces
{
    public interface IBookService
    {
        Task<List<BookGetDTO>> GetAllBooks();

        Task<BookGetDTO> GetBookById(Guid id);
        }
}