using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using AwsAdmin.Application.Ec2.Interface;

namespace AwsAdmin.Application.Ec2
{
    public class ElasticIpService : IElasticIpService
    {
        private readonly IAmazonEC2 _cloudComputeClient;

        public ElasticIpService(IAmazonEC2 cloudComputeClient)
        {
            _cloudComputeClient = cloudComputeClient;
        }

        public async Task<AllocateAddressResponse> AllocateAddressAsync()
        {
            var request = new AllocateAddressRequest();
            var response = await _cloudComputeClient.AllocateAddressAsync(request);
            return response;
        }

        public async Task<AssociateAddressResponse> AssociateAddressAsync(string instanceId, string publicIp)
        {
            var request = new AssociateAddressRequest(instanceId, publicIp);
            var response = await _cloudComputeClient.AssociateAddressAsync(request);
            return response;
        }
    }
}
