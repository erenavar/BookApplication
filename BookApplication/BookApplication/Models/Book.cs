using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApplication.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Definition { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(10,5000)]
        public double Price { get; set; }

        public int BookTypeId { get; set; }

        [ForeignKey("BookTypeId")]
        public BookType BookType { get; set; }

        public string PicUrl { get; set; }
    }
}
