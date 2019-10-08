using Amazon.EC2;
using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2
{
    public class VpcService
    {
        private readonly IAmazonEC2 _amazonEC2Client;

        public VpcService(IAmazonEC2 amazonEC2Client)
        {
            _amazonEC2Client = amazonEC2Client;
        }

        public async Task<CreateVpcResponse> CreateVpcAsync(string cidrBlock)
        {
            var request = new CreateVpcRequest(cidrBlock);
            var response = await _amazonEC2Client.CreateVpcAsync(request);
            return response;
        }

        public async Task<DescribeVpcsResponse> DescribeVpcsAsync()
        {
            var response = await _amazonEC2Client.DescribeVpcsAsync();
            return response;
        }

        /// <summary>
        //     Deletes the specified VPC. You must detach or delete all gateways and resources
        //     that are associated with the VPC before you can delete it. For example, you must
        //     terminate all instances running in the VPC, delete all security groups associated
        //     with the VPC (except the default one), delete all route tables associated with
        //     the VPC (except the default one), and so on.
        /// </summary>
        /// <returns></returns>
        public async Task<DeleteVpcResponse> DeleteVpcAsync(string vpcId)
        {
            var request = new DeleteVpcRequest(vpcId);
            var response = await _amazonEC2Client.DeleteVpcAsync(request);
            return response;
        }
    }
}
