using Business.AmazonWebServices.Ec2;
using Business.AmazonWebServices.Ec2.Interface;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.Ec2
{
    public class InternetGatewayServiceTests
    {
        [Test]
        public async Task CreateInternetGatewayAsync_should_create_and_return_internetGateway()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            IInternetGatewayService classUnderTest = new InternetGatewayService(client);

            // Act
            var response = await classUnderTest.CreateInternetGatewayAsync();

            // Assert
            Assert.IsTrue(response.InternetGateway != null);
            Assert.IsTrue(response.InternetGateway.InternetGatewayId.Length > 0);
        }

        [Test]
        public async Task AttachInternetGatewayAsync_should_attach_give_internetgateway_to_vpc()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            IInternetGatewayService classUnderTest = new InternetGatewayService(client);

            // Act
            var internetGatewayId = "igw-045502c2b6932babd";
            var vpcId = "vpc-08e1953cac632841a";
            var response = await classUnderTest.AttachInternetGatewayAsync(internetGatewayId, vpcId);

            // Assert
        }
    }
}
