using System;
using System.Collections.Generic;
using System.Text;
using Data.Domain.Entities;

namespace Data.Domain.Interfaces
{
    public interface IPlaceRepository : IRepository<Place>
    {
        Place GetByName(string name);
    }
}
