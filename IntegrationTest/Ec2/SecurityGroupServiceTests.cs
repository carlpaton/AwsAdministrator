using Business.AmazonWebServices.Ec2;
using Business.AmazonWebServices.Ec2.Interface;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.Ec2
{
    public class SecurityGroupServiceTests
    {
        [Test]
        public async Task DescribeSecurityGroupAsync_when_any_exist_should_describe_security_groups()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            ISecurityGroupService classUnderTest = new SecurityGroupService(client);

            // Act
            var response = await classUnderTest.DescribeSecurityGroupsAsync();

            // Assert
            Assert.IsTrue(response.SecurityGroups.Count >= 1);
        }
    }
}
