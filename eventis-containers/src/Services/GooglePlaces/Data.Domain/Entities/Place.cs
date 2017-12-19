using System;
using System.Collections.Generic;

namespace Data.Domain.Entities
{
    public class Place
    {
        private Place()
        {
            
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool OpenNow { get; set; }
        // photos
        // categories
        // schedule

        public void Update(string name, double rating, string address, double latitude, double longitude, bool opennow)
        {
            this.Name = name;
            this.Rating = rating;
            this.Address = address;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.OpenNow = opennow;
        }

        public static Place Create(string name, double rating, string address, double latitude, double longitude, bool opennow)
        {
            var instance = new Place { Id = Guid.NewGuid() };
            instance.Update(name, rating, address, latitude, longitude, opennow);
            return instance;
        }
    }
}
