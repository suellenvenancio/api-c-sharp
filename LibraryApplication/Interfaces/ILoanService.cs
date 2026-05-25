using LibraryApplication.DTO.Loan;
 
namespace LibraryApplication.Service.Interfaces
{
    public interface ILoanService
    { 
        Task<LoanGetDTO> GetLoanByUserId(Guid userId);
        Task<LoanGetDTO> GetLoanByBookId(Guid bookId);
        Task<LoanGetDTO> CreateLoan(LoanPostDTO loanPostDTO);
        Task<LoanGetDTO> UpdateLoan(LoanPatchDTO loanPutDTO);
    }
}