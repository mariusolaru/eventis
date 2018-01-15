using System;

namespace PlacesAPI.Entities
{
    public class Place
    {
        public long Id { get; set; }
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Rating { get; set; }
        public string Address { get; set; }
        //public string Photos { get; set; }
        //public string Types { get; set; }
        //public bool OpenNow { get; set; }
        //public string Schedule { get; set; }
    }
}
