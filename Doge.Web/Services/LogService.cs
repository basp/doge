namespace Doge.Web.Services
{
    using Dapper;
    using Doge.Web.Models;
    using DotLiquid;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public class LogService
    {
        static readonly string connectionString =
            ConfigurationManager.AppSettings.Get("connectionString");

        public void InsertEvent(dynamic fields, params string[] tags)
        {
            var xml = Serialize(fields, tags);
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(
                    "[doge].[log_event]",
                    new { data = xml },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<LogEvent> Search(params string[] tags)
        {
            var source = Utils.ReadEmbeddedString("Doge.Web.Resources.search.sql");
            var template = Template.Parse(source);
            var data = new { tags };
            var hash = Hash.FromAnonymousObject(data);
            var sql = template.Render(hash);

            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query(sql)
                    .Select(x => new LogEvent
                    {
                        Id = x.id,
                        Data = XDocument.Parse(x.data),
                        LoggedAt = x.logged_at
                    });
            }
        }

        private static string Serialize(dynamic fields, params string[] tags)
        {
            var @event = new
            {
                // shuffling to make sure it serializes as desired
                tags = new { tag = tags },
                fields
            };

            var json = JsonConvert.SerializeObject(@event);
            var doc = (XmlDocument)JsonConvert.DeserializeXmlNode(
                json,
                "event");

            return doc.OuterXml;
        }
    }
}