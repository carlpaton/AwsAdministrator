using AwsAdmin.Infrastructure;
using AwsAdmin.Infrastructure.Interface;
using System;

namespace IntegrationTest.AwsAdmin.Application.Plumbing
{
    /// <summary>
    /// Dump AWS response to serialzed file.
    /// This was helpful when I needed to compare what I created using the `AWS Console` vs `AWS SDK`
    /// </summary>
    public class ResponseToJsonFile
    {
        private readonly IJsonSerializationService _jsonSerializationService;
        private readonly IBase64EncodeService _base64EncodeService;
        private readonly IDirectoryService _directoryService;
        private readonly IFileWriteService _fileWriteService;

        public ResponseToJsonFile() 
        {
            // This is how DI works, right?  * troll-face-here *
            _jsonSerializationService = new JsonSerializationService();
            _base64EncodeService = new Base64EncodeService();
            _directoryService = new DirectoryService();
            _fileWriteService = new FileWriteService();
        }

        public void Go(string prefix, object data) 
        {
            return;

            var path = _directoryService.BaseDirectory();
            var fileName = $"{prefix}_{Guid.NewGuid()}.txt";
            var contents = _jsonSerializationService.SerializeObject(data);

            _fileWriteService.AppendAllText(path, fileName, contents);
        }
    }
}
