using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;

namespace Business.AmazonWebServices.Ec2
{
    public class SubnetService : ISubnetService
    {
        private readonly IAmazonEC2 _cloudComputeClient;

        public SubnetService(IAmazonEC2 cloudComputeClient)
        {
            _cloudComputeClient = cloudComputeClient;
        }

        public async Task<CreateSubnetResponse> CreateSubnetAsync(string vpcId, string cidrBlock)
        {
            var request = new CreateSubnetRequest(vpcId, cidrBlock);
            var response = await _cloudComputeClient.CreateSubnetAsync(request);
            return response;
        }

        public async Task<DescribeSubnetsResponse> DescribeSubnetsAsync()
        {
            var response = await _cloudComputeClient.DescribeSubnetsAsync();
            return response;
        }

        public async Task<DeleteSubnetResponse> DeleteSubnetAsync(string subnetId)
        {
            var request = new DeleteSubnetRequest(subnetId);
            var response = await _cloudComputeClient.DeleteSubnetAsync(request);
            return response;
        }
    }
}
