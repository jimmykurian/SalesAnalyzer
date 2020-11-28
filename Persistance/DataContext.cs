using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<StateRegion> StateRegions { get; set; }
        public DbSet<CountryRegion> CountryRegions { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
