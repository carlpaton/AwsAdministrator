using AwsAdmin.Application.Ecs;
using AwsAdmin.Application.Ecs.Interface;
using IntegrationTest.AwsAdmin.Application.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.AwsAdmin.Application.Ecs
{
    public class TaskServiceTests
    {
        [Test]
        public async Task DescribeTaskDefinitionAsync_when_any_exist_should_describe_taskDefinitions()
        {
            // Arrange
            var taskDefinition = "lexicon-task-definition";
            var client = new EnvironmentVariables().ContainerServiceClient();
            ITaskService classUnderTest = new TaskService(client);

            // Act
            var response = await classUnderTest.DescribeTaskDefinitionAsync(taskDefinition);

            // Assert
            Assert.IsTrue(response.TaskDefinition.Family.Equals(taskDefinition));
        }

        [Test]
        public async Task ListTaskDefinitionsAsync_when_any_exist_should_list_taskDefinitions()
        {
            // Arrange
            var client = new EnvironmentVariables().ContainerServiceClient();
            ITaskService classUnderTest = new TaskService(client);

            // Act
            var response = await classUnderTest.ListTaskDefinitionsAsync();

            // Assert
            Assert.IsTrue(response.TaskDefinitionArns.Count > 0);
        }
    }
}
