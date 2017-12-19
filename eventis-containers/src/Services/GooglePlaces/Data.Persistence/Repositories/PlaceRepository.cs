using System.Linq;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence.Context;

namespace Data.Persistence.Repositories
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(DatabaseContext context) : base(context)
        {
            
        }
        public Place GetByName(string name)
        {
            return DbSet.FirstOrDefault(c => c.Name == name);
        }
    }
}
