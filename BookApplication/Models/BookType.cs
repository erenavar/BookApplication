using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookApplication.Models
{
    public class BookType
    {
        [Key]
        public int Id { get; set; }

        [Required]
//        [DisplayName("Book Type Name")]
        public string Name { get; set; }
    }
}
