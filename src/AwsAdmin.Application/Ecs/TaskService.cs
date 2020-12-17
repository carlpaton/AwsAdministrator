using Amazon.ECS;
using Amazon.ECS.Model;
using AwsAdmin.Application.Ecs.Interface;
using System.Threading.Tasks;

namespace AwsAdmin.Application.Ecs
{
    public class TaskService : ITaskService
    {
        private readonly IAmazonECS _containerServiceClient;

        public TaskService(IAmazonECS containerServiceClient)
        {
            _containerServiceClient = containerServiceClient;
        }

        public async Task<DescribeTaskDefinitionResponse> DescribeTaskDefinitionAsync(string taskDefinition)
        {
            var request = new DescribeTaskDefinitionRequest
            {
                TaskDefinition = taskDefinition
            };

            var response = await _containerServiceClient.DescribeTaskDefinitionAsync(request);
            return response;
        }

        public async Task<ListTaskDefinitionsResponse> ListTaskDefinitionsAsync()
        {
            var request = new ListTaskDefinitionsRequest();
            var response = await _containerServiceClient.ListTaskDefinitionsAsync(request);
            return response;
        }
    }
}
