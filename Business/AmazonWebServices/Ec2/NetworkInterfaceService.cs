using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;

namespace Business.AmazonWebServices.Ec2
{
    public class NetworkInterfaceService : INetworkInterfaceService
    {
        private readonly IAmazonEC2 _amazonEC2Client;

        public NetworkInterfaceService(IAmazonEC2 amazonEC2Client)
        {
            _amazonEC2Client = amazonEC2Client;
        }

        public async Task<CreateNetworkInterfaceResponse> CreateNetworkInterfaceAsync(string subnetId)
        {
            var request = new CreateNetworkInterfaceRequest
            {
                SubnetId = subnetId
            };

            var response = await _amazonEC2Client.CreateNetworkInterfaceAsync(request);
            return response;
        }

        public async Task<DescribeNetworkInterfacesResponse> DescribeNetworkInterfacesAsync()
        {
            var request = new DescribeNetworkInterfacesRequest();
            var response = await _amazonEC2Client.DescribeNetworkInterfacesAsync(request);
            return response;
        }
    }
}
