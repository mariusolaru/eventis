using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using EnsureThat;

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

        public static string DailyMailHtmlBodyFirstPart =
            System.IO.File.ReadAllText(GetDailyEmailHtmlTemplateFirstPartPath());

        public static string DailyMailHtmlBodySecondPart =
            System.IO.File.ReadAllText(GetDailyEmailHtmlTemplateSecondPartPath());

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

        public static string GetDailyEmailHtmlTemplateFirstPartPath()
        {
            var assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var directoryPath = Path.GetDirectoryName(assemblyPath);

            var filePath = Path.Combine(directoryPath, @"..\..\..\..\Data.Domain\Resources\DailyHTMLTemplateFirstPart.txt");

            return filePath;
        }

        public static string GetDailyEmailHtmlTemplateSecondPartPath()
        {
            var assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var directoryPath = Path.GetDirectoryName(assemblyPath);

            var filePath = Path.Combine(directoryPath, @"..\..\..\..\Data.Domain\Resources\DailyHTMLTemplateSecondPart.txt");

            return filePath;
        }

        public static string CreateDailyMailHtmlComponent(string eventName, string eventLocation, string imageUrl , string startTime, string endTime)
        {
            EnsureArg.IsNotNullOrEmpty(eventName);
            EnsureArg.IsNotNullOrEmpty(eventLocation);
            EnsureArg.IsNotNullOrEmpty(imageUrl);
            EnsureArg.IsNotNullOrEmpty(startTime);
            EnsureArg.IsNotNullOrEmpty(endTime);

            string htmlComponent = "";

            htmlComponent += "<div class=\"grid-grid\">";
            htmlComponent += "<div class=\"grid-news-img\">";
            htmlComponent += "<img src=\"" + imageUrl + "\" alt = \"\" /> ";
            htmlComponent += "</div>";
            htmlComponent += "<div class=\"grid-news-txt\">";
            htmlComponent += "<p>" + eventName + "</p>";
            htmlComponent += "<p>" + eventLocation + "</p>";
            htmlComponent += "<a class=\"news-link\">" + startTime.Substring(11,5) + " - " + endTime.Substring(11,5) + "</a >";
            htmlComponent += "</div>";
            htmlComponent += "</div>";

            return htmlComponent;

        }


    }
}
