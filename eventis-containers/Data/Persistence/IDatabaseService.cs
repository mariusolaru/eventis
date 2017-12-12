using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public interface IDatabaseService
    {
        DbSet<UserList> UsersList { get; set; }
        int SaveChanges();
    }
}
