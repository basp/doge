namespace Doge.Web.Controllers
{
    using DotLiquid;
    using System.Configuration;
    using System.Web.Mvc;

    public class AppController : Controller
    {
        static readonly string connectionString =
            ConfigurationManager.AppSettings.Get("connectionString");

        readonly QueryParser parser = new QueryParser();

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Test(string q)
        {
            var m = this.parser.Parse(q);
            var d = new
            {
                predicates = m.Predicates,
                count = 50
            };

            var t = Template.Parse(Utils.ReadEmbeddedString("Doge.Web.Resources.search.sql"));
            var h = Hash.FromAnonymousObject(d);
            var sql = t.Render(h);

            this.ViewBag.sql = sql;

            return this.View();
        }
    }
}