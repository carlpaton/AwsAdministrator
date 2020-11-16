using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;
using Amazon.S3;
using Business.AmazonWebServices.S3;
using Business.AmazonWebServices.S3.Interface;

namespace IntegrationTest.S3
{
    public class BucketServiceTests
    {
        private const string BucketName = "bucket-280e70fe-ee15-46e1-99e8-ba5b46669e2a";

        private IAmazonS3 _s3BucketClient;

        [SetUp]
        public void SetUp()
        {
            _s3BucketClient = new EnvironmentVariables().S3BucketClient();
        }

        [Test]
        public async Task PutBucketAsync_creates_bucket()
        {
            // Arrange
            IBucketService classUnderTest = new BucketService(_s3BucketClient);

            // Act
            var response = await classUnderTest
                .PutBucketAsync(BucketName);

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task ListBucketsAsync_lists_buckets_for_user()
        {
            // Arrange
            IBucketService classUnderTest = new BucketService(_s3BucketClient);

            // Act
            var response = await classUnderTest.ListBucketsAsync();

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(response.Buckets.Count > 0);
        }
    }
}
