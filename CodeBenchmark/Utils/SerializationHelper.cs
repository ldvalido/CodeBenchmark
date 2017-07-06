using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CodeBenchmark.Utils
{
    public static class SerializationHelper
    {
        public static string Serialize<T>(T obj)
        {
            var sb = new StringBuilder();

            var sw = new StringWriter(sb);

            var serializer = new XmlSerializer(typeof(T));

            serializer.Serialize(sw, obj);
            
            return sb.ToString();
        }

        public static void SerializeToFile<T>(T obj, string fileName)
        {
            var fileContent = Serialize(obj);
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.WriteAllText(fileName,fileContent,Encoding.Unicode);
        }
        
        public static  T Deserealize<T> (string fileName)
        {
            var returnValue = default(T);
            if (File.Exists(fileName))
            {
                var serializer = new XmlSerializer(typeof (T));

                var streamReader = new StreamReader(fileName, Encoding.Unicode);

                returnValue = (T) serializer.Deserialize(streamReader);
            }
            return returnValue;
        }
    }
}
