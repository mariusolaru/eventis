using System;

namespace Data.Domain
{
    public class Event
    {
        private Event()
        {
            //Entity Framework
        }
        public String Location { get; set; }

        public Guid Id { get; set; }

        public string FacebookId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string ImageUrl { get; set; }

        public static Event Create(string location, string facebookId, string name, string description, DateTime startTime, DateTime endTime, string imageUrl)
        {
            //TODO : add defensive coding !
            var instance = new Event
            {
                Id = Guid.NewGuid()
            };
            instance.Update(location, facebookId, name, description, startTime, endTime, imageUrl);
            return instance;
        }

        public void Update(string location, string facebookId, string name, string description, DateTime startTime, DateTime endTime, string imageUrl)
        {
            this.Location = location;
            this.FacebookId = facebookId;
            this.Name = name;
            this.Description = description;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.StartTime = startTime;
            this.EndTime = endTime;

            this.ImageUrl = imageUrl;
        }
    }
}
