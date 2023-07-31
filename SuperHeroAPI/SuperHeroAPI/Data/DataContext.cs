using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=SuperHeroApi; Username=ryan; Password=password");
            // base.OnConfiguring(optionsBuilder);
            // optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=superherodb;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
