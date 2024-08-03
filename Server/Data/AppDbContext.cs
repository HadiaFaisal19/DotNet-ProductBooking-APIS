using Admin.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Admin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
