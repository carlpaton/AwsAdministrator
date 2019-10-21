using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;

namespace Business.AmazonWebServices.Ec2
{
    public class SubnetService : ISubnetService
    {
        private readonly IAmazonEC2 _amazonEC2Client;

        public SubnetService(IAmazonEC2 amazonEC2Client)
        {
            _amazonEC2Client = amazonEC2Client;
        }

        public async Task<CreateSubnetResponse> CreateSubnetAsync(string vpcId, string cidrBlock)
        {
            var request = new CreateSubnetRequest(vpcId, cidrBlock);
            var response = await _amazonEC2Client.CreateSubnetAsync(request);
            return response;
        }

        public async Task<DescribeSubnetsResponse> DescribeSubnetsAsync()
        {
            var response = await _amazonEC2Client.DescribeSubnetsAsync();
            return response;
        }

        public async Task<DeleteSubnetResponse> DeleteSubnetAsync(string subnetId)
        {
            var request = new DeleteSubnetRequest(subnetId);
            var response = await _amazonEC2Client.DeleteSubnetAsync(request);
            return response;
        }
    }
}
