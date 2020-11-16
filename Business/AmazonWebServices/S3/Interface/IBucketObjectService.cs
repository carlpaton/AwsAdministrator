using System.Threading.Tasks;
using Amazon.S3.Model;

namespace Business.AmazonWebServices.S3.Interface
{
    public interface IBucketObjectService
    {
        /* TODO - implement
         *
         * GetPreSignedURL
         * GetObjectMetadata
         * ListObjects
         */


        /// <summary>
        /// Put the plaintext object in the S3 bucket
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
    }
}
