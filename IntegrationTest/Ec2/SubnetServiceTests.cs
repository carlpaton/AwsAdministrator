using Business.AmazonWebServices.Ec2;
using Business.AmazonWebServices.Ec2.Interface;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.Ec2
{
    public class SubnetServiceTests
    {
        [Test]
        public async Task CreateSubnetAsync_should_create_and_return_subnet()
        {
            // Arrange
            var vpcId = "vpc-08e1953cac632841a";
            var cidrBlock1 = "10.0.1.0/24";
            var cidrBlock2 = "10.0.0.0/24";

            var client = new EnvironmentVariables().CloudComputeClient();
            ISubnetService classUnderTest = new SubnetService(client);

            // Act
            var response = await classUnderTest.CreateSubnetAsync(vpcId, cidrBlock1);
            var response2 = await classUnderTest.CreateSubnetAsync(vpcId, cidrBlock2);

            // Assert
            Assert.IsTrue(response.Subnet != null);
            Assert.IsTrue(response.Subnet.SubnetId.Length > 1);
        }

        [Test]
        public async Task DescribeSubnetsAsync_when_any_exist_should_describe_subnets()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            ISubnetService classUnderTest = new SubnetService(client);

            // Act
            var response = await classUnderTest.DescribeSubnetsAsync();

            // Assert
            Assert.IsTrue(response.Subnets.Count >= 1);
        }

        [Test]
        public async Task DeleteSubnetAsync_when_vpcId_exists_should_delete()
        {
            // Arrange
            var subnetId = "subnet-0c7f1fd88bd8b7694";
            var client = new EnvironmentVariables().CloudComputeClient();
            ISubnetService classUnderTest = new SubnetService(client);

            // Act
            var response = await classUnderTest.DeleteSubnetAsync(subnetId);

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
