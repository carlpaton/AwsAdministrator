using Business.AmazonWebServices.Ec2;
using Business.AmazonWebServices.Ec2.Interface;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.Ec2
{
    public class NetworkAclsServiceTests
    {
        [Test]
        public async Task DescribeNetworkAclsAsync_when_any_exist_should_describe_network_acls()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            INetworkAclsService classUnderTest = new NetworkAclsService(client);

            // Act
            var response = await classUnderTest.DescribeNetworkAclsAsync();

            // Assert
            Assert.IsTrue(response.NetworkAcls != null);
            Assert.IsTrue(response.NetworkAcls.Count >= 1);
        }
    }
}
