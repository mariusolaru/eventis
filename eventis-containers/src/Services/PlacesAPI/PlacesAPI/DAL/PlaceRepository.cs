using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
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

        public Place GetPlaceById(Guid id)
        {
            return _context.Places.Find(id);
        }

        public void InsertPlace(Place place)
        {
            _context.Places.Add(place);
        }

        public void DeletePlace(Guid id)
        {
            var searchedPlace = _context.Places.Find(id);

            _context.Places.Remove(searchedPlace);
        }

        public void DeleteAll()
        {
            foreach (var it in _context.Places)
            {
                DeletePlace(it.Id);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void GetPlacesIasi(string givenType)
        {
            SearchPlaceType type = SearchPlaceType.Cafe;

            if (givenType == "airport")
            {
                type = SearchPlaceType.Airport;
            }
            else if (givenType == "atm")
            {
                type = SearchPlaceType.Atm;
            }
            else if (givenType == "bank")
            {
                type = SearchPlaceType.Bank;
            }
            else if (givenType == "beautysalon")
            {
                type = SearchPlaceType.BeautySalon;
            }
            else if (givenType == "bookstore")
            {
                type = SearchPlaceType.BookStore;
            }
            else if (givenType == "cafe")
            {
                type = SearchPlaceType.Cafe;
            }
            else if (givenType == "carwash")
            {
                type = SearchPlaceType.CarWash;
            }
            else if (givenType == "church")
            {
                type = SearchPlaceType.Church;
            }
            else if (givenType == "gasstation")
            {
                type = SearchPlaceType.GasStation;
            }
            else if (givenType == "gym")
            {
                type = SearchPlaceType.Gym;
            }
            else if (givenType == "hospital")
            {
                type = SearchPlaceType.Hospital;
            }
            else if (givenType == "library")
            {
                type = SearchPlaceType.Library;
            }
            else if (givenType == "club")
            {
                type = SearchPlaceType.NightClub;
            }
            else if (givenType == "park")
            {
                type = SearchPlaceType.Park;
            }
            else if (givenType == "restaurant")
            {
                type = SearchPlaceType.Restaurant;
            }
            else if (givenType == "school")
            {
                type = SearchPlaceType.School;
            }
            else if (givenType == "mall")
            {
                type = SearchPlaceType.ShoppingMall;
            }
            else if (givenType == "university")
            {
                type = SearchPlaceType.University;
            }
            else if (givenType == "zoo")
            {
                type = SearchPlaceType.Zoo;
            }

            var request = new PlacesNearBySearchRequest
            {
                Location = new Location(47.1584549, 27.601441),
                Radius = 5000,
                Type = type,
                Key = "AIzaSyDIBvIu8PiqdBewk342wTL7B9M-ym5bK84"
            };

            var result = GooglePlaces.NearBySearch.Query(request);

            Place place = new Place();

            foreach (var it in result.Results)
            {
                Place placeToInsert = place.Create(it.PlaceId, it.Name, it.Geometry.Location.Latitude, it.Geometry.Location.Longitude,
                    it.Rating, it.Vicinity, it.IconUrl);

                _context.Add(placeToInsert);
            }
        }
    }
}
