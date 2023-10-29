using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Utility
{
    public class ApplicationDbContext : IdentityDbContext
    {   
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
         public DbSet<BookType> BookTypes { get; set; }
         public DbSet<Book> Books { get; set; }
        public DbSet<Rent> Rentals { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

   
    }
}
