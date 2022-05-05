using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taboo.Data
{
    public class ResponseWrapper<TResponseModel>
    {
        public bool IsResponseSuccessfull { get; set; }
        public string Message { get; set; }
        public TResponseModel Response { get; set; }
    }
}
