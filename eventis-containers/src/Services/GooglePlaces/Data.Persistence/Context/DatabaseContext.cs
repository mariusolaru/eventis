using Microsoft.EntityFrameworkCore;

namespace Data.Persistence.Context
{
    public sealed class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Data.Domain.Entities.Place> Places { get; set; }
    }
}
