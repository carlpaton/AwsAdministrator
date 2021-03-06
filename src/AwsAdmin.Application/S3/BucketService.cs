﻿using Amazon.S3;
using Amazon.S3.Model;
using AwsAdmin.Application.S3.Interface;
using System.Threading.Tasks;

namespace AwsAdmin.Application.S3
{
    public class BucketService : IBucketService
    {
        private readonly IAmazonS3 _s3Client;

        public BucketService(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<DeleteBucketResponse> DeleteBucketAsync(string bucketName)
        {
            return await _s3Client
                .DeleteBucketAsync(bucketName);
        }

        public async Task<ListBucketsResponse> ListBucketsAsync()
        {
            return await _s3Client
                .ListBucketsAsync();
        }

        public async Task<PutBucketResponse> PutBucketAsync(string bucketName)
        {
            return await _s3Client
                .PutBucketAsync(bucketName);
        }
    }
}
