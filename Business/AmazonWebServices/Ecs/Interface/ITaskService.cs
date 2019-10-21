using Amazon.ECS.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ecs.Interface
{
    public interface ITaskService
    {
        Task<DescribeTaskDefinitionResponse> DescribeTaskDefinitionAsync(string taskDefinition);

        Task<ListTaskDefinitionsResponse> ListTaskDefinitionsAsync();
    }
}
