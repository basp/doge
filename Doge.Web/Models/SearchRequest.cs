namespace Doge.Web.Models
{
    using Newtonsoft.Json;
    using System;

    public class SearchRequest
    {
        [JsonProperty("q")]
        public string Q { get; set; }

        [JsonProperty("from")]
        public DateTime? From { get; set; }

        [JsonProperty("to")]
        public DateTime? To { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("count")]
        public int? Count { get; set; }
    }
}