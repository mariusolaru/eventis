using System;
using System.Collections.Generic;

namespace Data.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Password { get; set; }

        public virtual List<CustomEvent> CustomEvents;

    }
}
