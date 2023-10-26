using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

        [ValidateNever]
        public int BookTypeId { get; set; }

        [ForeignKey("BookTypeId")]
        [ValidateNever]
        public BookType BookType { get; set; }
        [ValidateNever]
        public string PicUrl { get; set; }
    }
}
