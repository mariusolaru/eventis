using Microsoft.EntityFrameworkCore;

namespace PlacesAPI.Entities
{
    public class PlaceContext : DbContext
    {
        public PlaceContext(DbContextOptions<PlaceContext> options) : base(options) { }

        public DbSet<Place> Places { get; set; }
    }
}
