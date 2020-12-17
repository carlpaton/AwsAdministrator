using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using AwsAdmin.Application.Ec2.Interface;

namespace AwsAdmin.Application.Ec2
{
    public class RouteTableService : IRouteTableService
    {
        private readonly IAmazonEC2 _cloudComputeClient;

        public RouteTableService(IAmazonEC2 cloudComputeClient)
        {
            _cloudComputeClient = cloudComputeClient;
        }

        public async Task<DescribeRouteTablesResponse> DescribeRouteTablesAsync()
        {
            var response = await _cloudComputeClient.DescribeRouteTablesAsync();
            return response;
        }
    }
}
