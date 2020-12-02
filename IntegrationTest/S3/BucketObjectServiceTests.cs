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

namespace IntegrationTest.S3
{
    public class BucketObjectServiceTests
    {
        private const string BucketName = "bucket-280e70fe-ee15-46e1-99e8-ba5b46669e2a";
        private const string FileName = "DummyModel.json";
        private const string FileNameWithMeta = "DummyModel-WithMeta.json";

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
                Age = 84,
                CreatedDate = DateTime.Now,
                FullName = "Foo Bar",
                Id = Guid.NewGuid()
            };
            var contentBody = _jsonSerializationService.SerializeObject(dummyModel);

            // Act
            var response = await classUnderTest
                .PutTextObjectAsync(BucketName, FileNameWithMeta, contentBody);

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
        public async Task GetPreSignedURL_should_get_url()
        {
            // Arrange
            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);

            // Act
            var actual = classUnderTest.GetPreSignedURL(BucketName, FileName, 1);

            // Assert
            StringAssert.Contains(BucketName, actual);
            StringAssert.Contains(FileName, actual);
        }

        [Test]
        public async Task GetObjectMetadataAsync_should_get_metadata()
        {
            // TODO - this is not working, I dont think the TagSet I used in `PutTextObjectAsync` worked. sad.

            // Arrange
            IBucketObjectService classUnderTest = new BucketObjectService(_s3BucketClient);

            // Act
            var actual = classUnderTest.GetObjectMetadataAsync(BucketName, FileName);

            // Assert
        }
    }
}
