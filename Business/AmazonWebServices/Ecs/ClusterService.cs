using Amazon.ECS;
using Amazon.ECS.Model;
using Business.AmazonWebServices.Ecs.Interface;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ecs
{
    public class ClusterService : IClusterService
    {
        private readonly IAmazonECS _containerServiceClient;

        public ClusterService(IAmazonECS containerServiceClient)
        {
            _containerServiceClient = containerServiceClient;
        }

        public async Task<CreateClusterResponse> CreateClusterAsync(string clusterName)
        {
            var request = new CreateClusterRequest
            {
                ClusterName = clusterName
            };

            var response = await _containerServiceClient.CreateClusterAsync(request);
            return response;
        }
    }
}
