using Amazon.ECS.Model;
using System.Threading.Tasks;

namespace AwsAdmin.Application.Ecs.Interface
{
    public interface ITaskService
    {
        Task<DescribeTaskDefinitionResponse> DescribeTaskDefinitionAsync(string taskDefinition);

        Task<ListTaskDefinitionsResponse> ListTaskDefinitionsAsync();
    }
}
