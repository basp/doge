namespace Doge.Web.Controllers
{
    using Dapper;
    using Newtonsoft.Json;
    using System.Data.SqlClient;
    using System.Web.Http;
    using System.Xml;

    public class LogController : ApiController
    {
        readonly string connectionString =
            @"Data Source=PREDATOR\SQLEXPRESS;Initial Catalog=sandbox;Integrated Security=SSPI";

        [HttpPost]
        [Route("api/log")]
        public dynamic LogEvent(dynamic @event)
        {
            var json = JsonConvert.DeserializeObject(@event);
            var xml = ((XmlDocument)JsonConvert.DeserializeXmlNode(json, "fields")).OuterXml;

            using(var conn = new SqlConnection(connectionString))
            {

            }

            return new { response = "ok" };
        }
    }
}
