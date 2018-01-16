using System;

namespace PlacesAPI.Entities
{
    public class Place
    {
        public Guid Id { get; set; }
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Rating { get; set; }
        public string Address { get; set; }
        public string Photos { get; set; }
        //public string Types { get; set; }

        public Place Create(string placeId, string name, double latitude, double longitude, double rating,
            string address, string photos)
        {
            var instance = new Place {Id = Guid.NewGuid()};
            instance.Update(placeId, name, latitude, longitude, rating, address, photos);

            return instance;
        }

        public void Update(string placeId, string name, double latitude, double longitude, double rating,
            string address, string photos)
        {
            PlaceId = placeId;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Rating = rating;
            Address = address;
            Photos = photos;
        }
    }
}
