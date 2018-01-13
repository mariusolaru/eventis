using System;

namespace UserManagement.API.Models
{
    public class UserListModel
    {
        public string Location { get; set; }
        public string Id { get; set; }
        public string FacebookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ImageURL { get; set; }
    }
}
