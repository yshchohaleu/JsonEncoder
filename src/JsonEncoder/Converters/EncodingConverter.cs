using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonEncoder.Converters
{
    public class EncodingConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(String);
        }

        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return WebUtility.HtmlEncode((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
