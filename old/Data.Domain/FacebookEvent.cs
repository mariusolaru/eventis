using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
    public class FacebookEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public int LocationId { get; set; }
    }
}
