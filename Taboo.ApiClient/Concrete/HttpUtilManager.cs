using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taboo.ApiClient.Abstract;

namespace Taboo.ApiClient.Concrete
{
    public class HttpUtilManager : IHttpUtilService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ISerializerService _serializerService;

        public HttpUtilManager(IHttpClientService httpClientService, ISerializerService serializerService)
        {
            _httpClientService = httpClientService;
            _serializerService = serializerService;
        }

        public async Task<T> Post<T>(string method, object input)
        {
            var param = new List<KeyValuePair<string, string>>() { };
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            if (input == null)
            {
                content = null;
            }
            var resultString = await _httpClientService.PostAsync(method, null, content);
            var result = _serializerService.DeserializeItem<T>(resultString);

            return result;
        }
        public async Task<T> Get<T>(string method, List<KeyValuePair<string, string>> param)
        {
            var resultString = await _httpClientService.GetAsync(method, param);
            var result = _serializerService.DeserializeItem<T>(resultString);
            return result;
        }
    }
}
