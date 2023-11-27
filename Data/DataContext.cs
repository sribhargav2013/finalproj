using Microsoft.EntityFrameworkCore;

namespace finalproj.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Add your DbSet properties here (e.g., DbSet<Pet> Pets { get; set; })
    }
}
