using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.DTO.Book
{
    public class BookPostDTO
    { 
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } 
        [Required(ErrorMessage = "ISBN is required.")]
        public string ISBN { get; set; } 

        [Required(ErrorMessage = "Publication Year is required.")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "CategoryId is required.")]
        public Guid CategoryId { get; set; }
 
    }
}