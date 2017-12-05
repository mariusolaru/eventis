using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
    public class CustomEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
