using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;
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

        public static string WelcomeHtmlBody = System.IO.File.ReadAllText(GetWelcomeHtmlTemplatePath());

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

        public static string GetWelcomeHtmlTemplatePath()
        {
            var assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var directoryPath = Path.GetDirectoryName(assemblyPath);

            var filePath = Path.Combine(directoryPath, @"..\..\..\..\Data.Domain\Resources\WelcomeHTMLTemplate.txt");
            
            return filePath;

        }   
    }
}
