using System.IO;
using System.Reflection;

namespace MVCWebApplication.DAL.EmbeddedReources
{
    public static class EmbeddedResource
    {
        public static string ReadEmbeddedReource(string filePath)
        {
            string file;

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filePath);

            using (StreamReader reader = new StreamReader(stream))
            {
                file = reader.ReadToEnd();
            }

            return file;
        }

    }
}
