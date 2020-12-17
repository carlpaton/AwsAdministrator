using Amazon.ECS.Model;
using System.Threading.Tasks;

namespace AwsAdmin.Application.Ecs.Interface
{
    public interface IClusterService
    {
        Task<CreateClusterResponse> CreateClusterAsync(string clusterName);
    }
}
