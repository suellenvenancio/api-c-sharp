namespace LibraryDomain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte[] HashedPassword { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public List<Loan> Loans { get; set; } = [];
    }
}

enum UserRole
{
    Admin,
    User
}