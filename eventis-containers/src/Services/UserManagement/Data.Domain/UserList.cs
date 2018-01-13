using System;

namespace Data.Domain
{
    public class UserList
    {
        private UserList()
        {

        }

        public Guid UserId { get; private set; }
        public string Location { get; private set; }
        public string Id { get; private set; }
        public string FacebookId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string ImageURL { get; private set; }

        public static UserList Create(string location, string id, string facebookId, string name,
            string description, DateTime startTime, DateTime endTime, string imageURL)
        {
            var instance = new UserList
            {
                UserId = Guid.NewGuid(),
                Location = location,
                Id = id , 
                FacebookId = facebookId ,
                Name = name , 
                Description = description ,
                StartTime = startTime , 
                EndTime = endTime , 
                ImageURL = imageURL
            };

            return instance;
        }

        public void Update(string location, string id, string facebookId, string name,
            string description, DateTime startTime, DateTime endTime, string imageURL)
        {
            this.Location = location;
            this.Id = id;
            this.FacebookId = facebookId;
            this.Name = name;
            this.Description = description;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.ImageURL = imageURL;
        }

    }
}
