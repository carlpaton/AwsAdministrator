using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Business.AmazonWebServices.S3.Interface;

namespace Business.AmazonWebServices.S3
{
    public class BucketObjectService : IBucketObjectService
    {
        private readonly IAmazonS3 _s3Client;

        public BucketObjectService(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<GetObjectResponse> GetObjectAsync(string bucketName, string key)
        {
            var request = new GetObjectRequest()
            {
                BucketName = bucketName,
                Key = key,
            };

            return await _s3Client
                .GetObjectAsync(request);
        }

        public async Task<PutObjectResponse> PutTextObjectAsync(string bucketName, string key, string contentBody)
        {
            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = key,
                ContentBody = contentBody,
            };

            return await _s3Client
                .PutObjectAsync(request);
        }

        public async Task<PutObjectResponse> PutTextObjectAsync(PutObjectRequest request)
        {
            return await _s3Client
                .PutObjectAsync(request);
        }

        public string GetPreSignedURL(string bucketName, string key, double expireInHours)
        {
            var request = new GetPreSignedUrlRequest()
            {
                BucketName = bucketName,
                Key = key,
                Expires = DateTime.UtcNow.AddHours(expireInHours)
            };

            return _s3Client
                .GetPreSignedURL(request);
        }

        public async Task<GetObjectMetadataResponse> GetObjectMetadataAsync(string bucketName, string key)
        {
            return await _s3Client
                .GetObjectMetadataAsync(bucketName, key);
        }

        public async Task<DeleteObjectResponse> DeleteObjectAsync(string bucketName, string key)
        {
            return await _s3Client
                .DeleteObjectAsync(bucketName, key);
        }

        public async Task<GetObjectTaggingResponse> GetObjectTaggingAsync(string bucketName, string key)
        {
            var request = new GetObjectTaggingRequest()
            {
                BucketName = bucketName,
                Key = key
            };

            return await _s3Client
                .GetObjectTaggingAsync(request);
        }

        public async Task<ListObjectsResponse> ListObjectsAsync(string bucketName)
        {
            return await _s3Client
                .ListObjectsAsync(bucketName);
        }
    }
}
