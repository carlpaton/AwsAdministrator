using System.IO;
using Business.AmazonWebServices.S3.Interface;
using NUnit.Framework;
using System.Threading.Tasks;
using Amazon.S3;
using Business.AmazonWebServices.S3;
using Common;
using Common.Interface;
using IntegrationTest.Plumbing;
using System;
using Business.AmazonWebServices.S3.Builder;
using System.Linq;
using Amazon.S3.Model;

namespace IntegrationTest.S3
{
    public class BucketObjectServiceTests
    {
        private const string BucketName = "bucket-280e70fe-ee15-46e1-99e8-ba5b46669e2a";
        private const string FileName = "DummyModel.json";
        private const string FileNameWithTag = "WithTag-DummyModel.json";
        private const string FileNameWithMetadata = "WithMetadata-DummyModel.json";
        private const string FileNameBinary = "Binary-DummyModel.txt";

        private IJsonSerializationService _jsonSerializationService;
        private IAmazonS3 _s3BucketClient;

        [SetUp]
        public void SetUp()
        {
            _jsonSerializationService = new JsonSerializationService();
            _s3BucketClient = new EnvironmentVariables().S3BucketClient();
        }

        [Test]
        public async Task PutTextObjectAsync_puts_text_file_in_bucket()
        {
            // Arrange
            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);
            var dummyModel = new DummyModel()
            {
                Age = 42,
                CreatedDate = DateTime.Now,
                FullName = "Foo Bar",
                Id = Guid.NewGuid()
            };
            var contentBody = _jsonSerializationService.SerializeObject(dummyModel);

            // Act
            var response = await classUnderTest
                .PutTextObjectAsync(BucketName, FileName, contentBody);

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task PutObjectAsync_should_create_object_with_tags()
        {
            // Arrange
            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);
            var dummyModel = new DummyModel()
            {
                Age = 1,
                CreatedDate = DateTime.MinValue,
                FullName = "Foo Bar",
                Id = Guid.NewGuid()
            };
            var contentBody = _jsonSerializationService.SerializeObject(dummyModel);
            
            var putObjectRequest = new PutObjectRequestBuilder(BucketName, FileNameWithTag, contentBody);
            putObjectRequest.WithTag("foo", "bar");
            putObjectRequest.WithTag("biz", "bat");

            // Act
            var response = await classUnderTest
                .PutObjectAsync(putObjectRequest.Create());

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task PutObjectAsync_should_create_object_with_metadata()
        {
            // Arrange
            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);
            var dummyModel = new DummyModel()
            {
                Age = 1,
                CreatedDate = DateTime.Now,
                FullName = "Fizz Buzz",
                Id = Guid.NewGuid()
            };
            var contentBody = _jsonSerializationService.SerializeObject(dummyModel);

            var putObjectRequest = new PutObjectRequestBuilder(BucketName, FileNameWithMetadata, contentBody);
            putObjectRequest.WithMetadata("biz", "bat");
            putObjectRequest.WithMetadata("fizz", "buzz");

            // Act
            var response = await classUnderTest
                .PutObjectAsync(putObjectRequest.Create());

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task PutObjectAsync_should_create_object()
        {
            // TODO - use the builder, I think take `contentBody` out of the ctr
            // TODO - PDF file?
            var filePath = @"C:\Dev\AwsAdministrator\Business\AmazonWebServices\S3\" + FileNameBinary;

            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);
            var contentType = "text/plain";
            var content = File.ReadAllBytes(filePath);

            // TODO - get content type from extension? 
            var fileInfo = new FileInfo(filePath);
            //contentType = fileInfo.

            var request = new PutObjectRequest
            {
                BucketName = BucketName,
                Key = FileNameBinary,
                ContentType = contentType,
                InputStream = new MemoryStream(content),
            };

            var response = await classUnderTest
                .PutObjectAsync(request);

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task GetObjectAsync_should_get_object()
        {
            // Arrange
            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);

            // Act
            var response = await classUnderTest.GetObjectAsync(BucketName, FileName);
            using (var reader = new StreamReader(response.ResponseStream))
            {
                // Not really needed for this test, I just thought it was cool
                var fileContent = await reader.ReadToEndAsync();
                var file = _jsonSerializationService.DeserializeObject<DummyModel>(fileContent);
            }

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
            Assert.AreEqual(FileName, response.Key);
        }

        [Test]
        public void GetPreSignedURL_should_get_url()
        {
            // Arrange
            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);
            var expireInHours = 1;

            // Act
            var actual = classUnderTest.GetPreSignedURL(BucketName, FileNameBinary, expireInHours);

            // Assert
            StringAssert.Contains(BucketName, actual);
            StringAssert.Contains(FileName, actual);
        }

        [Test]
        public async Task GetObjectMetadataAsync_should_get_metadata()
        {
            // Arrange
            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);

            // Act
            var response = await classUnderTest.GetObjectMetadataAsync(BucketName, FileNameWithMetadata);
            var actual = response.Metadata.Keys.Any(x => x.Equals("x-amz-meta-foo"));

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public async Task DeleteObjectAsync_should_delete_the_object()
        {
            // Arrange
            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);

            // Act
            var actual = await classUnderTest.DeleteObjectAsync(BucketName, FileName);

            // Assert
            Assert.AreEqual(actual.DeleteMarker, null);
        }

        [Test]
        public async Task GetObjectTaggingAsync_should_get_tags()
        {
            // Arrange
            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);

            // Act
            var response = await classUnderTest.GetObjectTaggingAsync(BucketName, FileNameWithTag);
            var actual = response.Tagging.Count();

            // Assert
            Assert.IsTrue(actual > 0);
        }

        [Test]
        public async Task ListObjectsAsync_()
        {
            // Arrange
            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);

            // Act
            var response = await classUnderTest.ListObjectsAsync(BucketName);
            var actual = response.S3Objects.Count();

            // Assert
            Assert.IsTrue(actual > 0);
        }
    }
}
