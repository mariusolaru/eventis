using System;

namespace UserManagement.API.Models
{
    public class UserListModel
    {   
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string EventType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
