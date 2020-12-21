using Microsoft.AspNetCore.StaticFiles;

namespace AwsAdmin.Infrastructure.Extensions
{
    public static class FileExtension
    {
        /// <summary>
        /// TODO - instead of an extension this could be a `MimeMappingService`
        /// then `FileExtensionContentTypeProvider` can be injected, mocked making `MimeMappingService` testable \ :D / 
        /// see: https://dotnetcoretutorials.com/2018/08/14/getting-a-mime-type-from-a-file-name-in-net-core/
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetContentType(this string filePath) 
        {
            new FileExtensionContentTypeProvider().TryGetContentType(filePath, out string contentType);
            return contentType ?? "application/octet-stream";
        }
    }
}
