using Microsoft.EntityFrameworkCore;
using Staycation.Api.Data.Models;
using Staycation.Api.Models;

namespace Staycation.Api.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Location>()
                .HasIndex(u => u.PostalCode)
                .IsUnique();
        }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
