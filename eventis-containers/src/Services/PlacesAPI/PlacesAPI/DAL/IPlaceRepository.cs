using System;
using System.Collections.Generic;
using PlacesAPI.Entities;

namespace PlacesAPI.DAL
{
    public interface IPlaceRepository
    {
        IEnumerable<Place> GetAllPlaces();
        Place GetPlaceById(long id);
        void InsertPlace(Place place);
        void DeletePlace(long id);
        void SaveChanges();
    }
}
