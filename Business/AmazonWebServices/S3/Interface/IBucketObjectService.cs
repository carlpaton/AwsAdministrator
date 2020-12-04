using System.Threading.Tasks;
using Amazon.S3.Model;

namespace Business.AmazonWebServices.S3.Interface
{
    public interface IBucketObjectService
    {
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
        /// Use `PutObjectRequestBuilder` to create the request object
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PutObjectResponse> PutTextObjectAsync(PutObjectRequest request);

        /// <summary>
        /// Deletes the given object (key)
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<DeleteObjectResponse> DeleteObjectAsync(string bucketName, string key);

        /// <summary>
        /// Get the value of the object on the bucket by reading `response.ResponseStream`
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<GetObjectResponse> GetObjectAsync(string bucketName, string key);

        /// <summary>
        /// Retrieves metadata from an object without returning the object itself.
        /// I think this is used as HTTP header data.
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<GetObjectMetadataResponse> GetObjectMetadataAsync(string bucketName, string key);

        /// <summary>
        /// Gets the tags as `response.Tagging`
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<GetObjectTaggingResponse> GetObjectTaggingAsync(string bucketName, string key);

        /// <summary>
        /// Gets data about the objects as `response.S3Objects` where `.Key` is the filename
        /// </summary>
        /// <param name="bucketName"></param>
        /// <returns></returns>
        Task<ListObjectsResponse> ListObjectsAsync(string bucketName);
    }
}
