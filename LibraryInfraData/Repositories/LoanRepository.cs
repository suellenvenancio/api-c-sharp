using LibraryDomain.Entities;
using LibraryDomain.Interfaces;
using LibraryInfraData.Context;

namespace LibraryInfraData.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;
        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Loan> GetLoanById(Guid id)
        {
           return await _context.Loan.FindAsync(id);
        }

        public async Task<Loan> GetLoanByUserId(Guid userId)
        {
            return await _context.Loan.FindAsync(userId);

        }

        public async Task<Loan> GetLoanByBookId(Guid bookId)
        {
            return await _context.Loan.FindAsync(bookId);
        }

        public async Task<Loan> CreateLoan(Loan loan)
        {
            await _context.Loan.AddAsync(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<Loan> UpdateLoan(Loan loan)
        {
            _context.Loan.Update(loan);
            await _context.SaveChangesAsync();
            return loan;
        }
    }
}