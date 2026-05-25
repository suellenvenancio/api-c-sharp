using LibraryApplication.DTO.Book;
using LibraryApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Book
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly BookServices _bookService;
        public BookController(BookServices bookService)
        {
            _bookService = bookService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<BookGetDTO>>> GetAllBooks()
        {
            var allBooks = await _bookService.GetAllBooks();
            return Ok(allBooks);
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<BookGetDTO>> GetBookById(Guid id)
        {
            var book = await _bookService.GetBookById(id);

            return Ok(book);
        }
    } 
}