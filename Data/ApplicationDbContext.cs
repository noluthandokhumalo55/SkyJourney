using Microsoft.EntityFrameworkCore;
using SKY_Journey.Models;
using System.Collections.Generic;

namespace SKY_Journey.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } // Represents the Clients table
    }
}
