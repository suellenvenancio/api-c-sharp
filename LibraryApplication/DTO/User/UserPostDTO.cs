using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.DTO.User
{
    public class UserPostDTO
    {   [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "CreatedAt is required.")]
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; } 

    }
}