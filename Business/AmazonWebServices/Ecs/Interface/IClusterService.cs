using Amazon.ECS.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ecs.Interface
{
    public interface IClusterService
    {
        Task<CreateClusterResponse> CreateClusterAsync(string clusterName);
    }
}
