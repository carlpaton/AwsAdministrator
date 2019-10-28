using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;

namespace Business.AmazonWebServices.Ec2
{
    public class InternetGatewayService : IInternetGatewayService
    {
        private readonly IAmazonEC2 _cloudComputeClient;

        public InternetGatewayService(IAmazonEC2 cloudComputeClient)
        {
            _cloudComputeClient = cloudComputeClient;
        }

        public async Task<AttachInternetGatewayResponse> AttachInternetGatewayAsync(string internetGatewayId, string vpcId)
        {
            var request = new AttachInternetGatewayRequest
            {
                InternetGatewayId = internetGatewayId,
                VpcId = vpcId
            };

            var response = await _cloudComputeClient.AttachInternetGatewayAsync(request);
            return response;
        }

        public async Task<CreateInternetGatewayResponse> CreateInternetGatewayAsync()
        {
            var request = new CreateInternetGatewayRequest();
            var response = await _cloudComputeClient.CreateInternetGatewayAsync();
            return response;
        }

        public async Task<DescribeInternetGatewaysResponse> DescribeInternetGatewaysAsync()
        {
            var request = new DescribeInternetGatewaysRequest();
            var response = await _cloudComputeClient.DescribeInternetGatewaysAsync(request);
            return response;
        }
    }
}
