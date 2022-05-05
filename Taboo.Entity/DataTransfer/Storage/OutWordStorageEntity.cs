using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taboo.Entity.DataTransfer.Storage
{
    public class OutWordStorageEntity : StorageEntityBase
    {
        public int WordId { get; set; }
        public DataTransfer.Storage.WordStorageEntity Word { get; set; }
        public int GameId { get; set; }
        public DataTransfer.Storage.GameStorageEntity Game { get; set; }
    }
}
