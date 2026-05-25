using LibraryDomain.Entities;

namespace LibraryDomain.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan> GetLoanById(Guid id);
        Task<Loan> GetLoanByUserId(Guid id); 
        Task<Loan> GetLoanByBookId(Guid id);
        Task<Loan> CreateLoan(Loan loan);
        Task<Loan> UpdateLoan(Loan loan);
    }
}