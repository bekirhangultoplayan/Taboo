using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Taboo.ApiClient.Abstract;

namespace Taboo.ApiClient.Concrete
{
    public class NewtonsoftJsonSerializerManager : ISerializerService
    {
        private readonly JsonSerializerSettings _typedSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public T DeserializeItem<T>(string serializedContent)
        {
            if (typeof(T) == typeof(string))
                return (T)((object)serializedContent);

            return JsonConvert.DeserializeObject<T>(serializedContent, _settings);
        }

        public string SerializeItem(object item)
        {
            if (typeof(string) == item.GetType())
                return (string)item;

            return JsonConvert.SerializeObject(item, _settings);
        }

        public T TypedDeserializeItem<T>(string serializedContent)
        {
            if (typeof(T) == typeof(string))
                return (T)((object)serializedContent);

            return JsonConvert.DeserializeObject<T>(serializedContent, _typedSettings);
        }

        public string TypedSerializeItem(object item)
        {
            if (typeof(string) == item.GetType())
                return (string)item;

            return JsonConvert.SerializeObject(item, _typedSettings);
        }
    }
}
