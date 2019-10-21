using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2.Interface
{
    public interface IVpcService
    {
        Task<DescribeVpcsResponse> DescribeVpcsAsync();

        /// <summary>
        /// AWS SKD will also create default `Security Group`, `Route Table`, `DHCP options sets` and `Network ACLs`
        /// </summary>
        /// <param name="cidrBlock">Example: 10.0.0.0/16</param>
        /// <returns></returns>
        Task<CreateVpcResponse> CreateVpcAsync(string cidrBlock);

        /// <summary>
        /// Deletes the specified VPC. You must detach or delete all gateways and resources
        /// that are associated with the VPC before you can delete it.For example, you must
        /// terminate all instances running in the VPC, delete all security groups associated
        /// with the VPC(except the default one), delete all route tables associated with
        /// the VPC(except the default one), and so on.
        /// </summary>
        /// <param name="vpcId"></param>
        /// <returns></returns>
        Task<DeleteVpcResponse> DeleteVpcAsync(string vpcId);
    }
}
