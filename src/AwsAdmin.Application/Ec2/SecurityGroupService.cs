using Amazon.EC2;
using Amazon.EC2.Model;
using AwsAdmin.Application.Ec2.Interface;
using System.Threading.Tasks;

namespace AwsAdmin.Application.Ec2
{
    public class SecurityGroupService : ISecurityGroupService
    {
        private readonly IAmazonEC2 _cloudComputeClient;

        public SecurityGroupService(IAmazonEC2 cloudComputeClient)
        {
            _cloudComputeClient = cloudComputeClient;
        }

        public async Task<DescribeSecurityGroupsResponse> DescribeSecurityGroupsAsync()
        {
            var request = new DescribeSecurityGroupsRequest();
            var response = await _cloudComputeClient.DescribeSecurityGroupsAsync(request);
            return response;
        }
    }
}
