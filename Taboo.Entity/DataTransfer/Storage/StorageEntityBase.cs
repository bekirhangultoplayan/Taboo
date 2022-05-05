using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taboo.Entity.DataTransfer.Storage
{
    public class StorageEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public bool IsDeleted { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime UpdateDate { get; set; }

    }
}
