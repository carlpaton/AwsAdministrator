using AwsAdmin.Application.Ec2;
using AwsAdmin.Application.Ec2.Interface;
using IntegrationTest.AwsAdmin.Application.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.AwsAdmin.Application.Ec2
{
    public class VpcServiceTests
    {
        [Test]
        public async Task CreateVpcAsync_should_create_and_return_vpc()
        {
            // Arrange
            var cidrBlock = "10.0.0.0/16";
            var client = new EnvironmentVariables().CloudComputeClient();
            IVpcService classUnderTest = new VpcService(client);
            
            // Act
            var response = await classUnderTest.CreateVpcAsync(cidrBlock);

            // Assert
            Assert.IsTrue(response.Vpc != null);
            Assert.IsTrue(response.Vpc.VpcId.Length > 1);
        }

        [Test]
        public async Task DescribeVpcsAsync_when_any_exist_should_describe_vpcs()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            IVpcService classUnderTest = new VpcService(client);

            // Act
            var response = await classUnderTest.DescribeVpcsAsync();

            // Assert
            Assert.IsTrue(response.Vpcs.Count >= 1);
        }

        [Test]
        public async Task DeleteVpcAsync_when_vpcId_exists_should_delete()
        {
            // Arrange
            var vpcId = "vpc-04bcccec7c7d8bff3";
            var client = new EnvironmentVariables().CloudComputeClient();
            IVpcService classUnderTest = new VpcService(client);

            // Act
            var response = await classUnderTest.DeleteVpcAsync(vpcId);

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task CreateDefaultVpcAsync_should_create_and_return_default_vpc()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            IVpcService classUnderTest = new VpcService(client);

            // Act
            var response = await classUnderTest.CreateDefaultVpcAsync();

            // Assert
            Assert.IsTrue(response.Vpc != null);
            Assert.IsTrue(response.Vpc.VpcId.Length > 1);
        }
    }
}