namespace WebApp.Common.Interface
{
    /// <summary>
    /// By default this is read from `C:\Users\[USERNAME]\.aws\credentials` which is what AWS CLI is using.
    /// If not the dev machine these need to be supplied as `EnvironmentVariable` or read from `appsettings.json`.
    /// </summary>
    public interface IKeyService
    {
        string GetAwsAccessKeyId();
        string GetAwsSecretAccessKey();
    }
}
