using Microsoft.EntityFrameworkCore;
using CarWebsite.Models;

namespace CarWebsite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<RentRequest> RentRequests { get; set; }
    }
}
