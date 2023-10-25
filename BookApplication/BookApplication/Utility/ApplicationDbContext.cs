using BookApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Utility
{
    public class ApplicationDbContext : DbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
         DbSet<BookType> BookTypes { get; set; }
         DbSet<Book> Books { get; set; }
   
    }
}
