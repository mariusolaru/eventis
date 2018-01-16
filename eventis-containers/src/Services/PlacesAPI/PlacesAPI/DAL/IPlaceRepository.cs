using System;
using System.Collections.Generic;
using PlacesAPI.Entities;

namespace PlacesAPI.DAL
{
    public interface IPlaceRepository
    {
        IEnumerable<Place> GetAllPlaces();
        Place GetPlaceById(Guid id);
        void InsertPlace(Place place);
        void DeletePlace(Guid id);
        void DeleteAll();
        void SaveChanges();
        void GetPlacesIasi(string type);
    }
}
