using Assignment1_EF_Core_.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1_EF_Core_.Data
{
    public class BookstoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ReadMoreBookstoreDb;Trusted_Connection=True;");
        }
    }
}
