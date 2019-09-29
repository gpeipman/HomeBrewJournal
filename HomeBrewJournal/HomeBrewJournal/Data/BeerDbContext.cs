using Microsoft.EntityFrameworkCore;

namespace HomeBrewJournal.Data
{
    public class BeerDbContext : DbContext
    {
        public BeerDbContext(DbContextOptions<BeerDbContext> options) : base(options)
        {
        }

        public DbSet<Beer> Beers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>().HasKey(b => b.Id);
            modelBuilder.Entity<Beer>().Property(b => b.Name).HasMaxLength(25).IsRequired();           

            base.OnModelCreating(modelBuilder);
        }
    }
}