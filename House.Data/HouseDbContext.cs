using House.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace House.Data
{
    public class HouseDbContext : DbContext
    {
        public HouseDbContext(DbContextOptions<HouseDbContext> options)
            : base(options) { }

        public DbSet<HouseNew> House { get; set; }

    }
}
