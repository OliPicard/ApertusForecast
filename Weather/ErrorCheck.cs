using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Weather
{
    [JsonConverter(typeof(ErrorResultConverter))]
    public class ErrorResult
    {
        public string title { get; set; }
        public int count { get; set; }
    }
    public class ErrorResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ErrorResult));
        }
        public override bool CanWrite { get { return false; } }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            JObject jo = JObject.Load(reader);

            var result = new ErrorResult
            {
                title = (string)jo.SelectToken("query.results.channel.title"),
                count = (int)jo.SelectToken("query.count")
            };

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}