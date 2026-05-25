using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.DTO.Loan
{
    public class LoanPostDTO
    {
        [Required(ErrorMessage = "UserId is required.")] 
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "BookId is required.")]
        public Guid BookId { get; set; }
        [Required(ErrorMessage = "LoanDate is required.")]
        public DateTime LoanDate { get; set; }
        [Required(ErrorMessage = "ReturnDate is required.")]
        public DateTime? ReturnDate { get; set; }
    }
}