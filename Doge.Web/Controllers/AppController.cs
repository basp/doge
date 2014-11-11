namespace Doge.Web.Controllers
{
    using System.Web.Mvc;

    public class AppController : Controller
    {
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

            return this.View();
        }
    }
}