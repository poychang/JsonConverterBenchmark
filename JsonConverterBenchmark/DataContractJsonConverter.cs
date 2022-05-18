using System.Runtime.Serialization.Json;
using System.Text;

namespace JsonConverterBenchmark
{
    public static partial class DataContractJsonConverter
    {
        /// <summary>
        /// 將 JSON 字串反序列化成物件
        /// </summary>
        public static T Deserialize<T>(string json)
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(stream)!;
        }

        /// <summary>
        /// 將物件序列化成字串
        /// </summary>
        public static string Serialize<T>(T obj)
        {
            using var ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(T)).WriteObject(ms, obj);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
