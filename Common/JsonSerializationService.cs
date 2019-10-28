using Common.Interface;
using Newtonsoft.Json;

namespace Common
{
    public class JsonSerializationService : IJsonSerializationService
    {
        public T DeserializeObject<T>(string valueToDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(valueToDeserialize);
        }

        public string SerializeObject(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}
