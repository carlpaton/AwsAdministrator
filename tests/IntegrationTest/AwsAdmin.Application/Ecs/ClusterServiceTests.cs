using AwsAdmin.Application.Ecs;
using AwsAdmin.Application.Ecs.Interface;
using IntegrationTest.AwsAdmin.Application.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.AwsAdmin.Application.Ecs
{
    public class ClusterServiceTests
    {
        [Test]
        public async Task CreateClusterAsync_should_create_and_return_cluster()
        {
            // Arrange
            var clusterName = "lexicon-cluster";
            var client = new EnvironmentVariables().ContainerServiceClient();
            IClusterService classUnderTest = new ClusterService(client);

            // Act
            var response = await classUnderTest.CreateClusterAsync(clusterName);

            // Assert
            Assert.IsTrue(response.Cluster != null);
            Assert.IsTrue(response.Cluster.ClusterName.Equals(clusterName));
        }
    }
}
