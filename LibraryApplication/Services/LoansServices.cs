using LibraryApplication.DTO.Loan;
using LibraryApplication.Exceptions;
using LibraryApplication.Service.Interfaces;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces;

namespace LibraryApplication.Services
{
    public class LoansServices : ILoanService
    {
  
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public LoansServices(ILoanRepository loanRepository)
        {
          
            _loanRepository = loanRepository;
        }

        public async Task<LoanGetDTO> GetLoanByUserId(Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            } 

            var loan = await _loanRepository.GetLoanByUserId(userId);
            if (loan == null)
            {
                throw new NotFoundException("Loan not found");
            }
            var loanDTO = new LoanGetDTO
            {
                Id = loan.Id,
                UserId = loan.UserId,
                BookId = loan.BookId,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate
            };        
            return loanDTO;
        }

        public async Task<LoanGetDTO> GetLoanByBookId(Guid bookId)
        {
            var book = await _bookRepository.GetBookById(bookId);
            if (book == null)            {
                throw new NotFoundException("Book not found");
            }

            var loan = await _loanRepository.GetLoanByBookId(bookId);
            if (loan == null)
            {
                throw new NotFoundException("Loan not found");
            }
            var loanDTO = new LoanGetDTO
            {
                Id = loan.Id,
                UserId = loan.UserId,
                BookId = loan.BookId,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate
            };
            return loanDTO;
        }

        public async Task<LoanGetDTO> CreateLoan(LoanPostDTO loanPostDTO)
        {
            var user = await _userRepository.GetUserById(loanPostDTO.UserId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var book = await _bookRepository.GetBookById(loanPostDTO.BookId);
            if (book == null)
            {
                throw new NotFoundException("Book not found");
            }

            var loan = new Loan
            {
                Id = Guid.NewGuid(),
                UserId = loanPostDTO.UserId,
                BookId = loanPostDTO.BookId,
                LoanDate = loanPostDTO.LoanDate,
                ReturnDate = loanPostDTO.ReturnDate
            };

            await _loanRepository.CreateLoan(loan);

            var loanDTO = new LoanGetDTO
            {
                Id = loan.Id,
                UserId = loan.UserId,
                BookId = loan.BookId,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate
            };
            return loanDTO;
        }

        public async Task<LoanGetDTO> UpdateLoan(LoanPatchDTO loanPutDTO)
        {
            var loan = await _loanRepository.GetLoanById(loanPutDTO.Id);
            if (loan == null)
            {
                throw new NotFoundException("Loan not found");
            }

            var user = await _userRepository.GetUserById(loanPutDTO.UserId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var book = await _bookRepository.GetBookById(loanPutDTO.BookId);
            if (book == null)
            {
                throw new NotFoundException("Book not found");
            }

            loan.UserId = loanPutDTO.UserId;
            loan.BookId = loanPutDTO.BookId;
            loan.LoanDate = loanPutDTO.LoanDate;
            loan.ReturnDate = loanPutDTO.ReturnDate;

            await _loanRepository.UpdateLoan(loan);

            var loanDTO = new LoanGetDTO
            {
                Id = loan.Id,
                UserId = loan.UserId,
                BookId = loan.BookId,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate
            };
            return loanDTO;
        }
    }
}