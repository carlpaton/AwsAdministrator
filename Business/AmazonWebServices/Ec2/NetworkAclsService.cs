using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;

namespace Business.AmazonWebServices.Ec2
{
    public class NetworkAclsService : INetworkAclsService
    {
        private readonly IAmazonEC2 _amazonEC2Client;

        public NetworkAclsService(IAmazonEC2 amazonEC2Client)
        {
            _amazonEC2Client = amazonEC2Client;
        }

        public async Task<DescribeNetworkAclsResponse> DescribeNetworkAclsAsync()
        {
            var response = await _amazonEC2Client.DescribeNetworkAclsAsync();
            return response;
        }
    }
}
