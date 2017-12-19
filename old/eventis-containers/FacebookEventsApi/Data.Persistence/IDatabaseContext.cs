using Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<Event> Events { get; set; }
        int SaveChanges();
    }
}
