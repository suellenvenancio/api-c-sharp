using System;
using LibraryDomain.Entities;

namespace LibraryDomain.Interfaces
{
    public interface IBookRepository
    {  
        Task<Book> GetBookById(int id);
        Task<List<Book>>GetAllBooks(); 
    }
}