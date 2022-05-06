using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taboo.ApiClient.Abstract
{
    public interface IHttpClientService
    {
        Task<string> PostAsync(string url, List<KeyValuePair<string, string>> parameters, StringContent json = null);
        Task<string> GetAsync(string url, List<KeyValuePair<string, string>> parameters = null);
        Task<string> PutAsync(string url, List<KeyValuePair<string, string>> parameters, StringContent json = null);
    }
}
