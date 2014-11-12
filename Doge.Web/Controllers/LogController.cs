namespace Doge.Web.Controllers
{
    using Doge.Web.Services;
    using System.Linq;
    using System.Web.Http;

    public class LogController : ApiController
    {
        readonly LogService service = new LogService();

        [HttpGet]
        [Route("api/log/tag/{tag}")]
        public dynamic Search([FromUri] string tag)
        {
            var tags = SplitTagString(tag);
            var events = this.service.Search(tags);
            return new { events };
        }

        [HttpPost]
        [Route("api/log/tag/{tag}")]
        public dynamic Log([FromUri] string tag, [FromBody] dynamic fields)
        {
            var tags = SplitTagString(tag);
            this.service.InsertEvent(fields, tags);
            return new { response = "ok" };
        }

        [HttpPost]
        [Route("api/log")]
        public dynamic Log([FromBody] dynamic fields)
        {
            this.service.InsertEvent(fields);
            return new { response = "ok" };
        }

        private static string[] SplitTagString(string tag)
        {
            return tag.Split(new[] { ',' })
                .Select(x => x.Trim().Replace(' ', '_').Replace('.', '_'))
                .ToArray();
        }
    }
}
