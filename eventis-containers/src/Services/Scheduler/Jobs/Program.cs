using System;
using System.Net;

namespace Jobs
{
    class Program
    {
        static void Main(string[] args)
        {
            string sURL;
            sURL = "http://localhost:51288/v1/events/update";

            WebRequest GetURL;
            GetURL = WebRequest.Create(sURL);
        }
    }
}
