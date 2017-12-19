using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FacebookCrawler.Models;
using Newtonsoft.Json;

namespace FacebookCrawler
{
    public interface IFacebookClient
    {
        Task<List<Location>> GetLocations(string accessToken);
        Task<List<Event>> GetEvents(string accessToken, List<Location> locations);
    }
    public class FacebookClient : IFacebookClient
    {
        private readonly HttpClient _httpClient;

        public FacebookClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/v2.8/")
            };
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Event>> GetEvents(string accessToken, List<Location> locations)
        {
            List<Event> events = new List<Event>();

            List<List<string>> chunks = new List<List<string>>();
            List<string> tempList = new List<string>();

            foreach (var location in locations)
            {
                tempList.Add(location.Id);
                if (tempList.Count >= 50)
                {
                    chunks.Add(tempList);
                    tempList = new List<string>();
                }
            }

            if (tempList.Count > 0)
            {
                chunks.Add(tempList);
            }

            var eventsFields = new string[]
            {
                "id",
                "name",
                "description",
                "cover.fields(id,source)",
                "start_time", 
                "end_time",
                "category",
            };

            var fields = new string[]
            {
                "id",
                "name",
                "events.fields(" + String.Join(",", eventsFields) + ")"
            };

            foreach (var chunk in chunks)
            {
                var eventsUrl = "?ids=" + String.Join(",", chunk) + "&access_token="
                                + accessToken + "&fields=" + String.Join(",", fields) +
                                ".since(" + new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds() + ")";

                var response = await _httpClient.GetAsync(eventsUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    dynamic jsonData = JsonConvert.DeserializeObject(result);

                    foreach (var id in chunk)
                    {
                        if (jsonData[id].events != null)
                        {
                            //TODO : check edge cases 

                            var someEvents =
                                JsonConvert.DeserializeObject<List<Event>>(jsonData[id].events.data.ToString());

                            foreach (var ev in someEvents)
                            {
                                ev.Place = jsonData[id].name.ToString();
                            }
                            events.AddRange(someEvents);
                        }
                    }
                }
            }

            return events;
        }

        public async Task<List<Location>> GetLocations(string accessToken)
        {
            List<Location> locations = new List<Location>();

            var after = "";
            var requestUrl = "search?type=place&center=47.1694851,27.5751793&distance=10000&access_token=" + accessToken;

            do
            {
                var response = await _httpClient.GetAsync(requestUrl + after);

                if (!response.IsSuccessStatusCode)
                {
                    return default(List<Location>);
                }

                var result = await response.Content.ReadAsStringAsync();

                dynamic jsonData = JsonConvert.DeserializeObject(result);
                var partialResult = JsonConvert.DeserializeObject<List<Location>>(jsonData.data.ToString());

                locations.AddRange(partialResult);

                if (jsonData.paging != null && jsonData.paging.cursors != null && jsonData.paging.cursors.after != null)
                {
                    after = "&after=" + jsonData.paging.cursors.after;
                }
                else
                {
                    break;
                }
            } while (true);
            return locations;
        }
    }
}
