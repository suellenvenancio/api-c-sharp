using LibraryApplication.DTO.Loan;
using LibraryApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Loan
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : Controller
    {
        private readonly LoansServices _loansServices;

        public LoanController(LoansServices loansServices)
        {
            _loansServices = loansServices;
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<LoanGetDTO>>> GetLoansByUserId(Guid userId)
        {
            var allLoans = await _loansServices.GetLoanByUserId(userId);
            return Ok(allLoans);
        }

        [Authorize]
        [HttpGet("boo/{bookId}")]
        public async Task<ActionResult<LoanGetDTO>> GetLoanByBookId(Guid bookId)
        {
            var loan = await _loansServices.GetLoanByBookId(bookId);

            return Ok(loan);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<LoanGetDTO>> CreateLoan(LoanPostDTO loanPostDTO)
        {         
            var loan = await _loansServices.CreateLoan(loanPostDTO);
            return Ok(loan);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<LoanGetDTO>> UpdateLoan(LoanPatchDTO loanPutDTO)
        {
            var loan = await _loansServices.UpdateLoan(loanPutDTO);
            return Ok(loan);
        }
    }
}