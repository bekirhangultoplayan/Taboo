using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Taboo.ApiClient.Abstract;

namespace Taboo.ApiClient.Concrete
{
    public class HttpClientManager : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string _url = "";
        public HttpClientManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration.GetSection("TabooAPI:Url").Value;
            _url = "http://localhost:5186/api/";

            var _clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            _httpClient = new HttpClient(_clientHandler);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");

            _httpClient.BaseAddress = new Uri(_url);
        }
        public async Task<string> PostAsync(string url, List<KeyValuePair<string, string>> parameters, StringContent json = null)
        {

            HttpContent requestContent = null;
            if (parameters != null)
                requestContent = new FormUrlEncodedContent(parameters);
            if (json != null)
            {
                requestContent = json;
            }
            var responseMessage = (await _httpClient.PostAsync(_url + url, requestContent));
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                return await responseMessage.Content.ReadAsStringAsync();
            }
            else
            {
                var errorString = await responseMessage.Content.ReadAsStringAsync();
                HttpClientErrorModel errorResult = JsonConvert.DeserializeObject<HttpClientErrorModel>(errorString);
                throw new Exception(errorResult.Message);
            }
        }
        public async Task<string> GetAsync(string url, List<KeyValuePair<string, string>> parameters = null)
        {
           

            var resultList = new List<KeyValuePair<string, string>>();

            if (parameters != null)
                resultList.AddRange(parameters);
            var responseMessage = (await _httpClient.GetAsync(_url + url + GetQueryString(resultList)));
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                return await responseMessage.Content.ReadAsStringAsync();
            }
            else
            {
                var errorString = await responseMessage.Content.ReadAsStringAsync();
                HttpClientErrorModel errorResult = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpClientErrorModel>(errorString);
                throw new Exception(errorResult.Message);
            }

        }


        public async Task<string> PutAsync(string url, List<KeyValuePair<string, string>> parameters, StringContent json = null)
        {
            

            HttpContent requestContent = null;
            if (parameters != null)
                requestContent = new FormUrlEncodedContent(parameters);
            if (json != null)
            {
                requestContent = json;
            }
            var responseMessage = (await _httpClient.PutAsync(_url + url, requestContent));
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                return await responseMessage.Content.ReadAsStringAsync();
            }
            else
            {
                var errorString = await responseMessage.Content.ReadAsStringAsync();
                HttpClientErrorModel errorResult = JsonConvert.DeserializeObject<HttpClientErrorModel>(errorString);
                throw new Exception(errorResult.Message);
            }
        }
        private string GetQueryString(List<KeyValuePair<string, string>> list)
        {
            if (list != null && list.Any())
                return "?" + string.Join("&", list.Select(x => HttpUtility.UrlDecode(x.Key) + "=" + HttpUtility.UrlDecode(x.Value)));

            return "";
        }
    }
}
