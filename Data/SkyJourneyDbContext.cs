using Microsoft.EntityFrameworkCore;
using SKY_Journey.Models;

public class SkyJourneyDbContext : DbContext
{
    public SkyJourneyDbContext(DbContextOptions<SkyJourneyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }  // This is where the Clients table is mapped
}
