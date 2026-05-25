using System;
using LibraryDomain.Entities;

namespace LibraryDomain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories(); 
    }
}