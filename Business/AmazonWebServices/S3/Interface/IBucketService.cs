using System.Threading.Tasks;
using Amazon.S3.Model;

namespace Business.AmazonWebServices.S3.Interface
{
    public interface IBucketService
    {
        /* TODO - Implement bucket service contracts
         *
         * GetPreSignedURL
         * GetObjectMetadata
         * ListBuckets
         * ListObjects
         * PutBucket
         * PutObject
         */

        Task<GetObjectResponse> GetObjectAsync(string bucketName, string key);
    }
}
