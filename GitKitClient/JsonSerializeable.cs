using System.Web.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GitKitClient
{
    public abstract class JsonSerializeable
    {
        public string ToJson()
        {
            var settings = new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()};
            return JsonConvert.SerializeObject(this, settings);
        }
    }

    public abstract class JsonDeserializeable<T>
    {
        public T FromJson(string json)
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.DeserializeObject<T>(json,settings);
        }
    }
}