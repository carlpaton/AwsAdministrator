using AwsAdmin.Application.Ec2;
using AwsAdmin.Application.Ec2.Interface;
using IntegrationTest.AwsAdmin.Application.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.AwsAdmin.Application.Ec2
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

        // TODO - SecurityGroupServiceTests, grant 80, 22, 1433
    }
}
