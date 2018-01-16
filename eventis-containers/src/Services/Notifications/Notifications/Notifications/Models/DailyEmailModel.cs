using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public class DailyEmailModel
    {   
        public string Id { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public static Dictionary<string , string> GetDictionaryFromList(List<DailyEmailModel> dailyEmailList)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();

            string firstHtmlPart = Data.Domain.Email.DailyMailHtmlBodyFirstPart;

            string secondHtmlPart = Data.Domain.Email.DailyMailHtmlBodySecondPart;

            foreach (DailyEmailModel it in dailyEmailList)
            {

                Dict[it.Email] = firstHtmlPart;

            }

            foreach (DailyEmailModel it in dailyEmailList)
            {
                Dict[it.Email] +=
                    Data.Domain.Email.CreateDailyMailHtmlComponent(it.Name, it.Location, it.ImageUrl, it.StartTime.ToString(),
                        it.EndTime.ToString());

            }

            foreach (string key in new List<string>(Dict.Keys))
            {
                Dict[key] += secondHtmlPart;
            }

            return Dict;
        }

    }
}
