using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taboo.Entity.DataTransfer.Storage
{
    public class ForbiddenWordStorageEntity : StorageEntityBase
    {
        [StringLength(50)]
        public string ForbiddenWord { get; set; }

        public int WordId { get; set; }
        public DataTransfer.Storage.WordStorageEntity Word { get; set; }
    }
}
