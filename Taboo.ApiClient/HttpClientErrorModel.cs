using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taboo.ApiClient
{
    public class HttpClientErrorModel
    {
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
