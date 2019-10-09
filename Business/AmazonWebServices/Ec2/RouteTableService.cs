using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;

namespace Business.AmazonWebServices.Ec2
{
    public class RouteTableService : IRouteTableService
    {
        private readonly IAmazonEC2 _amazonEC2Client;

        public RouteTableService(IAmazonEC2 amazonEC2Client)
        {
            _amazonEC2Client = amazonEC2Client;
        }

        public async Task<DescribeRouteTablesResponse> DescribeRouteTablesAsync()
        {
            var response = await _amazonEC2Client.DescribeRouteTablesAsync();
            return response;
        }
    }
}
