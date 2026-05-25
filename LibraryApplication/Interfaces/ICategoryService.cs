using LibraryApplication.DTO.Category;

namespace LibraryApplication.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryGetDTO>> GetAllCategories();
    }
}