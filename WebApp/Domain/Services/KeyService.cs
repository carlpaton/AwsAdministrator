using System;
using WebApp.Domain.Services.Interface;

namespace WebApp.Domain.Services
{
    public class KeyService : IKeyService
    {
        private readonly string _awsAccessKeyId;
        private readonly string _awsSecretAccessKey;

        public KeyService(string awsAccessKeyId, string awsSecretAccessKey)
        {
            _awsAccessKeyId = awsAccessKeyId;
            _awsSecretAccessKey = awsSecretAccessKey;
        }

        public string GetAwsAccessKeyId()
        {
            if (!string.IsNullOrEmpty(_awsAccessKeyId))
                return _awsAccessKeyId;

            var ev = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
            if (ev != null)
                return ev;

            return "";
        }

        public string GetAwsSecretAccessKey()
        {
            if (!string.IsNullOrEmpty(_awsSecretAccessKey))
                return _awsSecretAccessKey;

            var ev = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY");
            if (ev != null)
                return ev;

            return "";
        }
    }
}
