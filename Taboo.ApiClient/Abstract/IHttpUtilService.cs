using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taboo.ApiClient.Abstract
{
    public interface IHttpUtilService
    {
        Task<T> Post<T>(string method, object input);
        Task<T> Get<T>(string method, List<KeyValuePair<string, string>> param);
    }
}
