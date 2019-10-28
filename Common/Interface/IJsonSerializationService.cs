namespace Common.Interface
{
    public interface IJsonSerializationService
    {
        string SerializeObject(object objectToSerialize);
        T DeserializeObject<T>(string valueToDeserialize);
    }
}
