using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookApplication.Models
{
    public class BookType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="This is not a default message.")]
        [MaxLength(30)]
        [DisplayName("Book Type Name")]
        public string Name { get; set; }
        public int MyProperty { get; set; }
    }
}
