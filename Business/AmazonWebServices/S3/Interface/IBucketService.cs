using System.Threading.Tasks;
using Amazon.S3.Model;

namespace Business.AmazonWebServices.S3.Interface
{
    public interface IBucketService
    {
        /* TODO - Implement
         *
         * DeleteBucketAsync
         */

        /// <summary>
        /// Creates the given bucket
        /// </summary>
        /// <param name="bucketName">Globally unique bucket name</param>
        /// <returns></returns>
        Task<PutBucketResponse> PutBucketAsync(string bucketName);

        /// <summary>
        /// Gets a list of buckets for the authenticated user
        /// </summary>
        /// <returns></returns>
        Task<ListBucketsResponse> ListBucketsAsync();
    }
}
