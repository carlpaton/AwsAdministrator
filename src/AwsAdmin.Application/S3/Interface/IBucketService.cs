using System.Threading.Tasks;
using Amazon.S3.Model;

namespace AwsAdmin.Application.S3.Interface
{
    public interface IBucketService
    {
        /// <summary>
        /// Creates the given bucket, note that buckets are globally unique in name.
        /// Will throw if the bucket already exists:
        /// 
        /// `Amazon.S3.AmazonS3Exception : Your previous request to create the named bucket succeeded and you already own it.`
        /// `Amazon.S3.AmazonS3Exception : The requested bucket name is not available. The bucket namespace is shared by all users of the system. Please select a different name and try again.`
        /// </summary>
        /// <param name="bucketName">Globally unique bucket name</param>
        /// <returns></returns>
        Task<PutBucketResponse> PutBucketAsync(string bucketName);

        /// <summary>
        /// Gets a list of buckets for the authenticated user
        /// </summary>
        /// <returns></returns>
        Task<ListBucketsResponse> ListBucketsAsync();

        /// <summary>
        /// Deletes the given bucket, will throw if its not empty.
        /// `Amazon.S3.AmazonS3Exception : The bucket you tried to delete is not empty`
        /// </summary>
        /// <param name="bucketName"></param>
        /// <returns></returns>
        Task<DeleteBucketResponse> DeleteBucketAsync(string bucketName);
    }
}
