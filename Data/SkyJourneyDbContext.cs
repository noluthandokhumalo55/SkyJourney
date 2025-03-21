using Microsoft.EntityFrameworkCore;
using SKY_Journey.Models;  // Correct namespace for the User model

namespace SKY_Journey.Data
{
    public class SkyJourneyDbContext : DbContext  // Renamed class to SkyJourneyDbContext
    {
        public SkyJourneyDbContext(DbContextOptions<SkyJourneyDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }  // Changed from Clients to Users
    }
}
