using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Weather
{
    [JsonConverter(typeof(QueryResultConverter))]
    public class QueryResult
    {
        public List<Forecast> Forecasts { get; set; }
        public string City { get; set; }
        public string SunRise { get; set; }
        public string SunSet { get; set; }
        public string Direction { get; set; }
        public string Speed { get; set; }
        public string link { get; set; }
        public string Condition { get; set; }
        public int Temperature { get; set; }
    }
    public class Forecast
    {
        public string date { get; set; }
        public string day { get; set; }
        public int high { get; set; }
        public int low { get; set; }
        public string text { get; set; }
    }
    public class QueryResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(QueryResult)); //new boolean overriding objectType with LineDiplay
        }
        public override bool CanWrite { get { return false; } }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            JObject jo = JObject.Load(reader); //new JObject reader (custom ReadJson Deseralizser)

            var result = new QueryResult
            {
                City = (string)jo.SelectToken("query.results.channel.location.city"),
                SunRise = (string)jo.SelectToken("query.results.channel.astronomy.sunrise"),
                Speed = (string)jo.SelectToken("query.results.channel.wind.speed"),
                link = (string)jo.SelectToken("query.results.channel.link"),
                Direction = (string)jo.SelectToken("query.results.channel.wind.direction"),
                SunSet = (string)jo.SelectToken("query.results.channel.astronomy.sunset"),
                Condition = (string)jo.SelectToken("query.results.channel.item.condition.text"),
                Temperature = (int)jo.SelectToken("query.results.channel.item.condition.temp"),
                Forecasts = jo.SelectToken("query.results.channel.item.forecast").ToObject<List<Forecast>>()
            };

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}