using System;
using System.Collections.Generic;
using System.Linq;
using PlacesAPI.Entities;

namespace PlacesAPI.DAL
{
    public class PlaceRepository : IPlaceRepository
    {
        private PlaceContext _context;

        public PlaceRepository(PlaceContext context)
        {
            _context = context;
        }

        public IEnumerable<Place> GetAllPlaces()
        {
            return _context.Places.ToList();
        }

        public Place GetPlaceById(long id)
        {
            return _context.Places.Find(id);
        }

        public void InsertPlace(Place place)
        {
            _context.Places.Add(place);
        }

        public void DeletePlace(long id)
        {
            var searchedPlace = _context.Places.Find(id);

            _context.Places.Remove(searchedPlace);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
