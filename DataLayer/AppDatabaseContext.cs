using BookApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApp.DataLayer
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext>options) : base(options) 
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
