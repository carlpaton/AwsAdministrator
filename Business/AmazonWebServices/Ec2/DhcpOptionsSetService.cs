using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2
{
    public class DhcpOptionsSetService : IDhcpOptionsSetService
    {
        private readonly IAmazonEC2 _cloudComputeClient;

        public DhcpOptionsSetService(IAmazonEC2 cloudComputeClient)
        {
            _cloudComputeClient = cloudComputeClient;
        }

        public async Task<DeleteDhcpOptionsResponse> DeleteDhcpOptionsAsync(string dhcpOptionsId)
        {
            var request = new DeleteDhcpOptionsRequest(dhcpOptionsId);
            var response = await _cloudComputeClient.DeleteDhcpOptionsAsync(request);
            return response;
        }

        public async Task<DescribeDhcpOptionsResponse> DescribeDhcpOptionsAsync()
        {
            var request = new DescribeDhcpOptionsRequest();
            var response = await _cloudComputeClient.DescribeDhcpOptionsAsync(request);
            return response;
        }
    }
}
