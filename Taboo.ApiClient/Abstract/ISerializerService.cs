using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taboo.ApiClient.Abstract
{
    public interface ISerializerService
    {
        string SerializeItem(object item);
        T DeserializeItem<T>(string serializedContent);

        string TypedSerializeItem(object item);
        T TypedDeserializeItem<T>(string serializedContent);
    }
}
