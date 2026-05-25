using LibraryApplication.DTO.Loan;

namespace LibraryApplication.DTO.User
{
    public class UserGetDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Role { get; set; }
        public List<LoanGetDTO?> Loans { get; set; } = [];

    }
}