using LibraryApplication.DTO.Author;
using LibraryApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Author
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<AuthorGetDTO>>> GetAllAuthors()
        {
            var allAuthors = await _authorService.GetAllAuthors();
            return Ok(allAuthors);
        }

         [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorGetDTO>> GetBookById(Guid id)
        {
            var author = await _authorService.GetAuthorById(id);

            return Ok(author);
        }
    } 
}