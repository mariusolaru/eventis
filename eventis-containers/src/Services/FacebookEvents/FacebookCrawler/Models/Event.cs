using System;
using Newtonsoft.Json;

namespace FacebookCrawler.Models
{
    public class Event
    {
        [JsonProperty("id")]
        public string FacebookId { get; set; }

        public String Place { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        public Cover Cover { get; set; }
    }
}
