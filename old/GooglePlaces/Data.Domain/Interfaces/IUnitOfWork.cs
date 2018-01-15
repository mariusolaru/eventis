using System;

namespace Data.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlaceRepository Places { get; set; }
        int Complete();
    }
}
