using Microsoft.EntityFrameworkCore;

namespace finalproj.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FinalProj;Integrated Security=True");
        }

        // Add your DbSet properties here (e.g., DbSet<Pet> Pets { get; set; })
    }
}
