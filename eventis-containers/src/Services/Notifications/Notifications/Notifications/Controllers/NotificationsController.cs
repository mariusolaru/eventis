using System.Collections.Specialized;
using Data.Domain;
using ElasticEmail.WebApiClient;
using Microsoft.AspNetCore.Mvc;
using Notifications.Models;

namespace Notifications.Controllers
{
    [Route("api/notifications")]
    public class NotificationsController
    {
        [HttpPost("welcome")]
        public void SendWelcomeEmail([FromBody] EmailAttrModel emailAttr)
        {
            NameValueCollection values = new NameValueCollection();
            values.Add("apikey", Email.APIKey);
            values.Add("from", Email.From);
            values.Add("fromName", Email.FromName);
            values.Add("to", emailAttr.To);
            values.Add("subject", "Welcome to EventIS");
            values.Add("bodyText", "Text Body");
            values.Add("bodyHtml", Email.WelcomeHtmlBody);
            values.Add("isTransactional", "true");

            string Response = Email.Send(Email.Address, values);

        }

    }
}
