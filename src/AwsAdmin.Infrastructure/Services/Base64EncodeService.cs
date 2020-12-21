using AwsAdmin.Application.Common.Interfaces;

namespace AwsAdmin.Infrastructure.Services
{
    public class Base64EncodeService : IBase64EncodeService
    {
        public string Encode(string base64Decoded)
        {
            string base64Encoded;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(base64Decoded);
            base64Encoded = System.Convert.ToBase64String(data);

            return base64Encoded;
        }
    }
}
