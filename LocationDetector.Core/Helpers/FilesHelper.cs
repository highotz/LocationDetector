using CsvHelper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace LocationDetector.Core.Helpers
{
    public class FilesHelper
    {

        public static List<T> ReadCsvFile<T>(StreamReader reader)
        {
            var lines = reader.ReadToEnd().Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.None);

            var objects = new List<T>();

            for (int i = 1; i < lines.Length; i++)
            {
                if (!String.IsNullOrEmpty(lines[i]))
                {
                    var values = lines[i].Split(',');

                    var obj = Activator.CreateInstance<T>();

                    typeof(T)
                        .GetProperties()
                        .Where(p => p.CanWrite)
                        .Select((p, index) => new { Property = p, Index = index })
                        .ToList()
                        .ForEach(p => p.Property.SetValue(obj, Convert.ChangeType(values[p.Index], p.Property.PropertyType)));

                    objects.Add(obj);
                }
            }

            return objects;
        }

        public static byte[] GenerateCsv<T>(List<T> objects)
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(objects);
                writer.Flush();
                memoryStream.Position = 0;

                return memoryStream.ToArray();
            }
        }

        public static List<T> ReadJsonlFile<T>(StreamReader reader)
        {
            using (reader)
            {
                var objects = new List<T>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var obj = JsonConvert.DeserializeObject<T>(line);
                    objects.Add(obj);
                }
                return objects;
            }
        }

        public static byte[] GenerateJsonl<T>(List<T> objects)
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            {
                foreach (var obj in objects)
                {
                    var jsonLine = JsonConvert.SerializeObject(obj);
                    writer.WriteLine(jsonLine);
                }
                writer.Flush();
                memoryStream.Position = 0;

                return memoryStream.ToArray();
            }
        }

    }
}
