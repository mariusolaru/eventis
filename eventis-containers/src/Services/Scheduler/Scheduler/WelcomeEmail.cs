using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler
{
    public class WelcomeEmail
    {
        public WelcomeEmail(string toWhom)
        {
            this.to = toWhom;
        }

        public string to { get; set; }
    }
}
