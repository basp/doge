namespace Doge.Web.Controllers
{
    using Doge.Web.Services;
    using DotLiquid;
    using System.Configuration;
    using System.Web.Mvc;

    public class AppController : Controller
    {
        static readonly string connectionString =
            ConfigurationManager.AppSettings.Get("connectionString");

        readonly QueryParser parser = new QueryParser();

        readonly LogService service = new LogService();

        [HttpGet]
        public ActionResult Index()
        {
            var recent = this.service.Search();
            return this.View(recent);
        }

        [HttpGet]
        public ActionResult Search(string tag)
        {
            var tags = Utils.SplitTagString(tag);
            var result = this.service.Search(tags);
            return this.View("Index", result);
        }
    }
}