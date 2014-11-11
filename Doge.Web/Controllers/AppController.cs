namespace Doge.Web.Controllers
{
    using DotLiquid;
    using System.Web.Mvc;

    public class AppController : Controller
    {
        readonly string connectionString =
            @"Data Source=PREDATOR\SQLEXPRESS;Initial Catalog=sandbox;Integrated Security=SSPI";

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

            var t = Template.Parse(Utils.ReadEmbeddedString("Doge.Web.Resources.filtered_events.sql"));
            var h = Hash.FromAnonymousObject(new { predicates = m.Predicates });
            var sql = t.Render(h);
            this.ViewBag.sql = sql;

            return this.View();
        }
    }
}