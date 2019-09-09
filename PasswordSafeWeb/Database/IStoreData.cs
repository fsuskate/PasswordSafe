namespace PasswordSafeWeb.Database
{
    public interface IStoreData
    {
        bool Save<T>(T obj, string dataFilePath);
        T Load<T>(string dataFilePath);
    }
}