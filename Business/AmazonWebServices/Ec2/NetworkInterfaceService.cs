using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;

namespace Business.AmazonWebServices.Ec2
{
    public class NetworkInterfaceService : INetworkInterfaceService
    {
        private readonly IAmazonEC2 _cloudComputeClient;

        public NetworkInterfaceService(IAmazonEC2 cloudComputeClient)
        {
            _cloudComputeClient = cloudComputeClient;
        }

        public async Task<CreateNetworkInterfaceResponse> CreateNetworkInterfaceAsync(string subnetId)
        {
            var request = new CreateNetworkInterfaceRequest
            {
                SubnetId = subnetId
            };

            var response = await _cloudComputeClient.CreateNetworkInterfaceAsync(request);
            return response;
        }

        public async Task<DescribeNetworkInterfacesResponse> DescribeNetworkInterfacesAsync()
        {
            var request = new DescribeNetworkInterfacesRequest();
            var response = await _cloudComputeClient.DescribeNetworkInterfacesAsync(request);
            return response;
        }
    }
}
