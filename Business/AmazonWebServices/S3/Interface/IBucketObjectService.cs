using System.Threading.Tasks;
using Amazon.S3.Model;

namespace Business.AmazonWebServices.S3.Interface
{
    public interface IBucketObjectService
    {
        /* TODO - implement
         *
         * GetObjectMetadata
         * ListObjects
         */

        /// <summary>
        /// Create a signed URL allowing access to a resource that would usually require authentication.
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <param name="expireInHours"></param>
        /// <returns></returns>
        string GetPreSignedURL(string bucketName, string key, double expireInHours);

        /// <summary>
        /// Put the plaintext object in the S3 bucket.
        /// The content type will be set to 'text/plain'.
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <param name="contentBody"></param>
        /// <returns></returns>
        Task<PutObjectResponse> PutTextObjectAsync(string bucketName, string key, string contentBody);

        /// <summary>
        /// Get the value of the object on the bucket by reading `response.ResponseStream`
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<GetObjectResponse> GetObjectAsync(string bucketName, string key);

        /// <summary>
        /// Retrieves metadata from an object without returning the object itself
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<GetObjectMetadataResponse> GetObjectMetadataAsync(string bucketName, string key);
    }
}
