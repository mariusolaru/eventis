using System;
using System.Diagnostics.Contracts;
using EnsureThat;

namespace Data.Domain
{
    public class UserList
    {
        private UserList()
        {

        }
        
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string Location { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public string EventType { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public static UserList Create(string userEmail , string location, string name,
            string description, string imageUrl , string eventType , DateTime startTime, DateTime endTime)
        {
            EnsureArg.IsNotNullOrEmpty(userEmail);
            EnsureArg.IsNotNullOrEmpty(location);
            EnsureArg.IsNotNullOrEmpty(name);
            EnsureArg.IsNotNullOrEmpty(description);
            EnsureArg.IsNotNullOrEmpty(imageUrl);
            EnsureArg.IsNotNullOrEmpty(eventType);
            EnsureArg.IsDateTime(startTime);
            EnsureArg.IsDateTime(endTime);

            var instance = new UserList
            {   
                Id = Guid.NewGuid(),
                UserEmail = userEmail,
                Location = location,
                Name = name, 
                Description = description ,
                ImageUrl = imageUrl,
                EventType = eventType,
                StartTime = startTime , 
                EndTime = endTime
            };

            return instance;
        }

        public void Update(string userEmail, string location, string name,
            string description, string imageUrl , string eventType , DateTime startTime, DateTime endTime)
        {
            EnsureArg.IsNotNullOrEmpty(userEmail);
            EnsureArg.IsNotNullOrEmpty(location);
            EnsureArg.IsNotNullOrEmpty(name);
            EnsureArg.IsNotNullOrEmpty(description);
            EnsureArg.IsNotNullOrEmpty(imageUrl);
            EnsureArg.IsNotNullOrEmpty(eventType);
            EnsureArg.IsDateTime(startTime);
            EnsureArg.IsDateTime(endTime);

            this.UserEmail = userEmail;
            this.Location = location;
            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.EndTime = endTime;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

    }
}
