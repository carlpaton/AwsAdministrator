using Business.AmazonWebServices.Ec2;
using Business.AmazonWebServices.Ec2.Interface;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.Ec2
{
    public class InstanceServiceTests
    {
        [Test]
        public async Task DescribeInstancesAsync_when_any_exist_should_describe_instances()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            IInstanceService classUnderTest = new InstanceService(client);

            // Act
            var response = await classUnderTest.DescribeInstancesAsync();

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);

            // Dump response
            new ResponseToJsonFile().Go("Instance_CreatedFromConsole", response);
        }

        [Test]
        public async Task RunInstancesAsync_should_run_the_given_launchTemplateId()
        {
            // Arrange
            var launchTemplateId = "lt-0dd03dd7c117aee20";
            var client = new EnvironmentVariables().CloudComputeClient();
            IInstanceService classUnderTest = new InstanceService(client);

            // Act
            var response = await classUnderTest.RunInstancesAsync(launchTemplateId);

            // Assert
        }
    }
}
