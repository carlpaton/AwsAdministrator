namespace AwsAdmin.Application.Common.Interfaces
{
    public interface IJsonSerializationService
    {
        string SerializeObject(object objectToSerialize);
        T DeserializeObject<T>(string valueToDeserialize);
    }
}
