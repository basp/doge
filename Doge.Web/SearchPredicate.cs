namespace Doge.Web
{
    using DotLiquid;
    using Newtonsoft.Json;

    public class SearchPredicate : ILiquidizable
    {
        [JsonProperty("xexp")]
        public string XExp { get; set; }

        [JsonProperty("neg")]
        public bool Neg { get; set; }

        public object ToLiquid()
        {
            return new
            {
                xexp = this.XExp,
                neg = this.Neg
            };
        }
    }
}