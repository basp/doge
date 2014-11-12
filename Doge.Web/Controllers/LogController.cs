namespace Doge.Web.Controllers
{
    using Dapper;
    using Doge.Web.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Http;
    using System.Xml;
    using System.Xml.Linq;

    public class LogController : ApiController
    {
        static readonly string connectionString =
            ConfigurationManager.AppSettings.Get("connectionString");
      
        [HttpPost]
        [Route("api/log/tag/{tag}")]
        public dynamic Log([FromUri] string tag, [FromBody] dynamic @event)
        {
            var tags = tag.Split(new[] { ',' })
                .Select(x => x.Trim().Replace(' ', '_').Replace('.', '_'))
                .ToArray();

            InsertEvent(@event, tags);
            return new { response = "ok" };
        }

        [HttpPost]
        [Route("api/log")]
        public dynamic Log([FromBody] dynamic @event)
        {
            InsertEvent(@event);
            return new { response = "ok" };
        }

        private void InsertEvent(dynamic @event, params string[] tags)
        {
            var t = new DataTable();
            t.Columns.Add("tag");

            foreach (var tag in tags)
            {
                var row = t.NewRow();
                row["tag"] = tag;
                t.Rows.Add(row);
            }

            var json = JsonConvert.DeserializeObject(@event);
            var xml = ((XmlDocument)JsonConvert.DeserializeXmlNode(json, "fields")).OuterXml;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(
                    "[doge].[log_event]",
                    new { data = xml, tags = t },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
