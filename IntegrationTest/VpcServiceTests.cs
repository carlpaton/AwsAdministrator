using Amazon.EC2;
using Business.AmazonWebServices.Ec2;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest
{
    public class VpcServiceTests
    {
        [SetUp]
        public void Setup()
        {
            new EnvironmentVariables();
        }

        [Test]
        public async Task CreateVpcAsync_should_create_and_return_vpc()
        {
            // Arrange
            var cidrBlock = "10.0.0.0/16";
            var client = new AmazonEC2Client();
            var classUnderTest = new VpcService(client);
            
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
            var client = new AmazonEC2Client();
            var classUnderTest = new VpcService(client);

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
            var client = new AmazonEC2Client();
            var classUnderTest = new VpcService(client);

            // Act
            var response = await classUnderTest.DeleteVpcAsync(vpcId);

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}