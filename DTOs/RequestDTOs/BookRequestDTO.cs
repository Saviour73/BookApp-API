using System.ComponentModel.DataAnnotations;

namespace BookApp.DTOs.RequestDTOs
{
    public class BookRequestDTO
    {
        [Required(ErrorMessage = "Author ID is required")] 
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
    }
}
