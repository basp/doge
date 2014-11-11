namespace Doge.Web
{
    using Newtonsoft.Json;

    public class SearchQuery
    {
        [JsonProperty("predicates")]
        public SearchPredicate[] Predicates { get; set; }
    }
}