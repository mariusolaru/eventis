using System;

namespace FacebookCrawler.Models
{
    public class Location
    {
        public string Id { get; set; }
        public String Name { get; set; }

        public Location(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
