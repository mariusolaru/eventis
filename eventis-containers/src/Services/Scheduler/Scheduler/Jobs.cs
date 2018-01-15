using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Scheduler
{
    public class Jobs
    {
        public void UpdateEvents()
        {
            string sURL = "http://localhost:51288/v1/events/update";

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            wrGETURL.GetResponse();
        }
    }
}
