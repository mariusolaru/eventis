using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Data.Domain.Persistence
{
    public interface IDatabaseService
    {
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}
