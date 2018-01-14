using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace Data.Domain
{
    public class Email
    {
        private Email()
        {

        }

        public const string APIKey = "8f98d225-9003-4484-96d9-5e897fb145f7";

        public const string Address = "https://api.elasticemail.com/v2/email/send";

        public const string From = "eventis.noreply@gmail.com";

        public const string FromName = "EventIS Team";

        public static string WelcomeHtmlBody = System.IO.File.ReadAllText(@"C:\Users\mariu\Desktop\.NET Laborators\Proiect .NET\eventis\eventis-containers\src\Services\Notifications\Notifications\Data.Domain\Resources\WelcomeHTMLTemplate.txt");

        public string To { get; set; }

        public string Subject { get; set; }

        public string BodyText { get; set; }

        public static string Send(string address, NameValueCollection values)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] apiResponse = client.UploadValues(address, values);
                    return Encoding.UTF8.GetString(apiResponse);

                }
                catch (Exception ex)
                {
                    return "Exception caught: " + ex.Message + "\n" + ex.StackTrace;
                }
            }
        }
    }
}
