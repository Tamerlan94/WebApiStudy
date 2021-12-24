using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Common> Commons { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasOne(p => p.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(f => f.CountryId);

            
        }
    }
}
