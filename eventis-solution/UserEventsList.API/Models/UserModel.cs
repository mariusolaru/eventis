using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Domain;

namespace UserEventsList.API.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Password { get; set; }

        public List<CustomEvent> CustomEvents;

    }
}
