namespace Doge.Web
{
    using System.Linq;
    using System.IO;

    public static class Utils
    {
        public static string[] SplitTagString(string tag)
        {
            return tag.Split(new[] { ',' })
                .Select(x => x.Trim().Replace(' ', '_').Replace('.', '_'))
                .ToArray();
        }

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