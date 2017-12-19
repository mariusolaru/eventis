using Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<UserList> UsersList { get; set; }
        int SaveChanges();
    }
}
