using AwsAdmin.Application.Ec2;
using AwsAdmin.Application.Ec2.Interface;
using IntegrationTest.AwsAdmin.Application.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.AwsAdmin.Application.Ec2
{
    public class DhcpOptionsSetServiceTests
    {
        [Test]
        public async Task DescribeDhcpOptionsAsync_when_any_exist_should_describe_dhcpOptions()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            IDhcpOptionsSetService classUnderTest = new DhcpOptionsSetService(client);

            // Act
            var response = await classUnderTest.DescribeDhcpOptionsAsync();

            // Assert
            Assert.IsTrue(response.DhcpOptions != null);
            Assert.IsTrue(response.DhcpOptions.Count >= 1);
        }

        [Test]
        public async Task DeleteDhcpOptionsAsync_when_dhcpOptionsId_exists_should_delete()
        {
            // Arrange
            var dhcpOptionsId = "dopt-01db9792f40e1f47d";
            var client = new EnvironmentVariables().CloudComputeClient();
            IDhcpOptionsSetService classUnderTest = new DhcpOptionsSetService(client);

            // Act
            var response = await classUnderTest.DeleteDhcpOptionsAsync(dhcpOptionsId);

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
