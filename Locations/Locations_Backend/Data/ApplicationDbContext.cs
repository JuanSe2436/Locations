using Microsoft.EntityFrameworkCore;

namespace Locations_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations => Set<Location>();
        public DbSet<LocalType> LocalTypes => Set<LocalType>();
        public DbSet<LocationClass> LocationClasses => Set<LocationClass>();
        public DbSet<Locality> Localities => Set<Locality>();
        public DbSet<LocalState> LocalStates => Set<LocalState>();
    }
}
