using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace EVenda.Venda.Utils
{
    public static class ParseJsonUtils
    {
        private static readonly UTF8Encoding Utf8NoBom = new UTF8Encoding(false);

        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.None,
            Converters = new JsonConverter[] { new StringEnumConverter() }
        };

        public static T ParseJson<T>(this byte[] json)
        {
            if (json == null || json.Length == 0) return default;
            var result = JsonConvert.DeserializeObject<T>(Utf8NoBom.GetString(json), JsonSettings);
            return result;
        }

    }
}
