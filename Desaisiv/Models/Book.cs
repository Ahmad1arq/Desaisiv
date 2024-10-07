using System.ComponentModel.DataAnnotations;

namespace Desaisiv.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string  Author { get; set; }
        [DataType(DataType.Date ,ErrorMessage="Invalid date ")]
 
        public int PublicionYear { get; set; }

    }
}
