using LibraryDomain.Entities;

namespace LibraryDomain.Interfaces
{
    public interface ICategory
    {
        Task<List<Category>> GetAllCategories(); 
    }
}