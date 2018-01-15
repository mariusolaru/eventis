using System;
using System.Collections.Generic;

namespace Data.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
