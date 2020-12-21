using AwsAdmin.Application.Common.Interfaces;
using Newtonsoft.Json;

namespace AwsAdmin.Infrastructure.Services
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
