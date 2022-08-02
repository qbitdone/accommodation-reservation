using Microsoft.EntityFrameworkCore;
using Staycation.Api.Data.Models;

namespace Staycation.Api.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Accommodation> Accommodations { get; set; }
    }
}
