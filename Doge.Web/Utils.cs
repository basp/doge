using System.IO;
namespace Doge.Web
{
    public static class Utils
    {
        public static string ReadEmbeddedString(string resourceName)
        {
            using (var stream = typeof(Utils).Assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}