using LibraryDomain.Entities;

namespace LibraryDomain.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan> GetLoanById(Guid id);
        Task<Loan> GetLoanByUserId(Guid id); 
    }
}