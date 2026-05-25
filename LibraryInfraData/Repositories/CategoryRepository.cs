using LibraryDomain.Entities;
using LibraryDomain.Interfaces;
using LibraryInfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryInfraData.Repositories {
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Category.ToListAsync();
        }
    }

}