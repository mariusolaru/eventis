using System;

namespace Data.Domain
{
    public class UserList
    {
        private UserList()
        {

        }
        
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public string Location { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public static UserList Create(string facebookId , string userEmail , string location, string name,
            string description, string imageUrl , DateTime startTime, DateTime endTime)
        {
            var instance = new UserList
            {   
                Id = facebookId,
                UserEmail = userEmail,
                Location = location,
                Name = name, 
                Description = description ,
                ImageUrl = imageUrl,
                StartTime = startTime , 
                EndTime = endTime
            };

            return instance;
        }

        public void Update(string facebookId , string userEmail, string location, string name,
            string description, string imageUrl , DateTime startTime, DateTime endTime)
        {
            this.Id = facebookId;
            this.UserEmail = userEmail;
            this.Location = location;
            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

    }
}
