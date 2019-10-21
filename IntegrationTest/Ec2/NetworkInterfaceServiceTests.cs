using Business.AmazonWebServices.Ec2;
using Business.AmazonWebServices.Ec2.Interface;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.Ec2
{
    public class NetworkInterfaceServiceTests
    {
        [Test]
        public async Task CreateNetworkInterfaceAsync_should_create_and_return_nic()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            var subNetId = "subnet-0c9880b42ac295441";
            INetworkInterfaceService classUnderTest = new NetworkInterfaceService(client);

            // Act
            var response = await classUnderTest.CreateNetworkInterfaceAsync(subNetId);

            // Assert
            Assert.IsTrue(response.NetworkInterface != null);
            Assert.IsTrue(response.NetworkInterface.NetworkInterfaceId.Length > 0);
        }

        [Test]
        public async Task DescribeNetworkInterfacesAsync_when_any_exist_should_describe_nics()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            INetworkInterfaceService classUnderTest = new NetworkInterfaceService(client);

            // Act
            var response = await classUnderTest.DescribeNetworkInterfacesAsync();

            // Assert
            Assert.IsTrue(response.NetworkInterfaces != null);
            Assert.IsTrue(response.NetworkInterfaces.Count > 0);
        }
    }
}
