using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taboo.Data.RequestModel
{
    public class WordAddRequestModel
    {
        [Required(ErrorMessage = "Word is required")]
        public string Word { get; set; }
        
        [Required(ErrorMessage = "ForbiddenWords is required")]
        public List<ForbiddenWordAddRequestModel> ForbiddenWords { get; set; }
    }
}
