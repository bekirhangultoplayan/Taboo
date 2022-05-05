using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taboo.Entity.DataTransfer.Storage
{
     
    public class GameStorageEntity : StorageEntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        
        public ICollection<OutWordStorageEntity> OutWords { get; set; }
    }
}
