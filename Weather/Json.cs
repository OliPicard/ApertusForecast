using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Weather
{
    [JsonConverter(typeof(WeatherConverter))]
    public class schema
    {
        public string Name { get; set; }
        public string SeverityDescription { get; set; }
        public string Reason { get; set; }
        public string Html { get; set; }
        public string forecast { get; set; }
    }
    public class WeatherConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(schema)); //new boolean overriding objectType with LineDiplay
        }
        public override bool CanWrite { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader); //new JObject reader (custom ReadJson Deseralizser)


            schema newItem = new schema();
            
            newItem.Name = (string)jo.SelectToken("query.results.channel.location.city"); //Get the name attrrib

            newItem.SeverityDescription = (string)jo.SelectToken("query.results.channel.item.condition.text");

            newItem.Reason = (string)jo.SelectToken("query.results.channel.item.condition.temp");

            newItem.Html = (string)jo.SelectToken("query.results.channel.item.description");

            newItem.forecast = (string)jo.SelectToken("query.results.channel.item.forecast");

            return newItem; //Return all items as newItem objects!
        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    
}

