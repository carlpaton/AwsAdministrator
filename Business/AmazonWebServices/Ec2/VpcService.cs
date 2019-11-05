using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2
{
    public class VpcService : IVpcService
    {
        private readonly IAmazonEC2 _cloudComputeClient;

        public VpcService(IAmazonEC2 cloudComputeClient)
        {
            _cloudComputeClient = cloudComputeClient;
        }

        public async Task<CreateVpcResponse> CreateVpcAsync(string cidrBlock)
        {
            var request = new CreateVpcRequest(cidrBlock);
            var response = await _cloudComputeClient.CreateVpcAsync(request);
            return response;
        }

        public async Task<DescribeVpcsResponse> DescribeVpcsAsync()
        {
            var response = await _cloudComputeClient.DescribeVpcsAsync();
            return response;
        }

        public async Task<DeleteVpcResponse> DeleteVpcAsync(string vpcId)
        {
            var request = new DeleteVpcRequest(vpcId);
            var response = await _cloudComputeClient.DeleteVpcAsync(request);
            return response;
        }

        public async Task<CreateDefaultVpcResponse> CreateDefaultVpcAsync()
        {
            var request = new CreateDefaultVpcRequest();
            var response = await _cloudComputeClient.CreateDefaultVpcAsync(request);
            return response;
        }
    }
}
