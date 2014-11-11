namespace Doge.Web
{
    using Newtonsoft.Json;

    public class SearchPredicate
    {
        [JsonProperty("xexp")]
        public string XExp { get; set; }

        [JsonProperty("neg")]
        public bool Neg { get; set; }
    }
}