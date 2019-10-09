using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2
{
    public class SecurityGroupService : ISecurityGroupService
    {
        private readonly IAmazonEC2 _amazonEC2Client;

        public SecurityGroupService(IAmazonEC2 amazonEC2Client)
        {
            _amazonEC2Client = amazonEC2Client;
        }

        public async Task<DescribeSecurityGroupsResponse> DescribeSecurityGroupsAsync()
        {
            var request = new DescribeSecurityGroupsRequest();
            var response = await _amazonEC2Client.DescribeSecurityGroupsAsync(request);
            return response;
        }
    }
}
