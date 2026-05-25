using LibraryApplication.DTO.Book;
using LibraryApplication.DTO.BookAuthor;
using LibraryApplication.DTO.Category;
using LibraryApplication.Service.Interfaces;
using LibraryDomain.Interfaces;

namespace LibraryApplication.Services
{
    public class CategoryServices : ICategoryService
    {
         private readonly ICategoryRepository _categoryRepository;
 

        public CategoryServices( ICategoryRepository categoryRepository)
        {
             _categoryRepository = categoryRepository;
           
        }

        public async Task<List<CategoryGetDTO>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            var categoryDTOs = new List<CategoryGetDTO>();
            foreach (var category in categories)
            {
                var categoryDTO = new CategoryGetDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    Books = category.Books.Select(b => new BookGetDTO
                    {
                        Id = b.Id,
                        Title = b.Title,
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
                        PublicationYear = b.PublicationYear,
                        Quantity = b.Quantity,
                        CategoryId = b.CategoryId
                    }).ToList()
                };
                categoryDTOs.Add(categoryDTO);
            }
            return categoryDTOs;
        }
    }
}