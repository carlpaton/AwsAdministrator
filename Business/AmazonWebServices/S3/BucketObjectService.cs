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
                //TagSet = new List<Tag>{
                //        new Tag { Key = "Keyx1", Value = "Value1"},
                //        new Tag { Key = "Keyx2", Value = "Value2" }
                //    }
            };

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

        public Task<GetObjectMetadataResponse> GetObjectMetadataAsync(string bucketName, string key)
        {
            return _s3Client
                .GetObjectMetadataAsync(bucketName, key);
        }
    }
}
