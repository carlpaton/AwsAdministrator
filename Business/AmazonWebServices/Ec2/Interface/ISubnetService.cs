using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2.Interface
{
    public interface ISubnetService
    {
        Task<DescribeSubnetsResponse> DescribeSubnetsAsync();

        Task<DeleteSubnetResponse> DeleteSubnetAsync(string subnetId);

        /// <summary>
        /// Creates a subnet in an existing VPC. When you create each subnet, you provide the VPC ID and IPv4 CIDR block for the subnet.
        /// </summary>
        /// <param name="vpcId"></param>
        /// <param name="cidrBlock">Example: 10.0.0.0/24</param>
        /// <returns></returns>
        Task<CreateSubnetResponse> CreateSubnetAsync(string vpcId, string cidrBlock);
    }
}
