namespace Doge.Web.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Xml.Linq;

    public class LogEvent
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("data")]
        public XDocument Data { get; set; }

        [JsonProperty("logged_at")]
        public DateTime LoggedAt {get;set;}
    }
}