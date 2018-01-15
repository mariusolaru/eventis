using System;
using System.Collections.Generic;
using System.Text;
using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence.Context
{
    public interface IDatabaseContext
    {
        DbSet<Place> Places { get; set; }
        int SaveChanges();
    }
}
