using System;
using Newtonsoft.Json;

namespace FacebookCrawler.Models
{
    public class Event
    {
        [JsonProperty("id")]
        public string FacebookId { get; set; } = "-1";

        public String Place { get; set; } = "no_name";

        [JsonProperty("name")]
        public String Name { get; set; } = "no_name";

        [JsonProperty("description")]
        public String Description { get; set; } = "no_description";

        [JsonProperty("start_time")]
        public string StartTime { get; set; } = "2018-01-15T20:30:00.000";

        [JsonProperty("end_time")]
        public string EndTime { get; set; } = "2018-01-15T22:00:00.000";

        public Cover Cover { get; set; } = new Cover();
    }
}
