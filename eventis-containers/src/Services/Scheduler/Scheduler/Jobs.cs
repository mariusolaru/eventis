using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Scheduler
{
    public class Jobs
    {
        public void UpdateEvents()
        {
            string sURL = "http://localhost:9000/fbevents/update";

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            wrGETURL.GetResponse();
        }

        public void SendWelcomeEmail()
        {
            var emailObject = new WelcomeEmail("romanescu.raz@gmail.com");
            string json = JsonConvert.SerializeObject(emailObject);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            WebRequest request = WebRequest.Create("http://localhost:9000/notifications/welcome");
            request.Method = "POST";
            request.ContentLength = byteArray.Length;
            request.ContentType = "application/json-patch+json";

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            request.GetResponse();
        }

        public void SendEmailsForToday()
        {
            string sURL = "http://localhost:9000/userslist/todaysevents";

            WebRequest wrGETURL = WebRequest.Create(sURL);

            Stream objectStream;
            objectStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objectReader = new StreamReader(objectStream);

            string sLine = "";
            string json = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objectReader.ReadLine();
                if (sLine != null)
                {
                    json += sLine;
                }
            }
            json = json.Replace("userEmail", "email");

            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            WebRequest request = WebRequest.Create("http://localhost:9000/notifications/dailymail");
            request.Method = "POST";
            request.ContentLength = byteArray.Length;
            request.ContentType = "application/json-patch+json";

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            request.GetResponse();
        }
    }
}
