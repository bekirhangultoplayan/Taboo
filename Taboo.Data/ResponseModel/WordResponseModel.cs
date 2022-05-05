using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taboo.Data.ResponseModel
{
    public class WordResponseModel
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public List<ForbiddenWordResponseModel> ForbiddenWords { get; set; }
    }
}
