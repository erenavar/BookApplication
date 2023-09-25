using System.ComponentModel.DataAnnotations;

namespace BookApplication.Models
{
    public class BookType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
