using Business.AmazonWebServices.Ec2;
using Business.AmazonWebServices.Ec2.Interface;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.Ec2
{
    public class ElasticIpServiceTests
    {
        [Test]
        public async Task AllocateAddressAsync_should_allocate_and_return_ip()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            IElasticIpService classUnderTest = new ElasticIpService(client);

            // Act
            var response = await classUnderTest.AllocateAddressAsync();

            // Assert
            Assert.IsTrue(response.PublicIp != null);
            Assert.IsTrue(response.PublicIp.Length > 1);
        }

        [Test]
        public async Task AssociateAddressAsync_should_associate_address_to_instance()
        {
            // Arrange
            var instanceId = "i-03dc1dd2a2762cd01";
            var publicIp = "13.210.233.36";
            var client = new EnvironmentVariables().CloudComputeClient();
            IElasticIpService classUnderTest = new ElasticIpService(client);

            // Act
            var response = await classUnderTest.AssociateAddressAsync(instanceId, publicIp);

            // Assert
            Assert.IsTrue(response.AssociationId != null);
            Assert.IsTrue(response.AssociationId.Length > 1);
        }
    }
}
