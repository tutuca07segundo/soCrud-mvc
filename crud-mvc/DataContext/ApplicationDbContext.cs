using crud_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_mvc.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<item_model> Items { get; set; } 
    }
}
