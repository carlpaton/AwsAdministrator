using Business.AmazonWebServices.Ecr;
using Business.AmazonWebServices.Ecr.Interface;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.Ecr
{
    public class ImagesServiceTests
    {
        [Test]
        public async Task ListImagesAsync_should_list_images_when_they_exist()
        {
            // Arrange
            var repositoryName = "lexicon-webmvc";
            var client = new EnvironmentVariables().ContainerRegistryClient();
            IImagesService classUnderTest = new ImagesService(client);

            // Act
            var response = await classUnderTest.ListImagesAsync(repositoryName);

            // Assert
            Assert.IsTrue(response.ImageIds.Count > 0);
        }
    }
}
