using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2.Interface
{
    public interface IInternetGatewayService
    {
        Task<DescribeInternetGatewaysResponse> DescribeInternetGatewaysAsync();

        Task<CreateInternetGatewayResponse> CreateInternetGatewayAsync();

        /// <summary>
        /// Attaches an internet gateway to a VPC, enabling connectivity between the internet and the VPC.
        /// </summary>
        /// <param name="internetGatewayId"></param>
        /// <param name="vpcId"></param>
        /// <returns></returns>
        Task<AttachInternetGatewayResponse> AttachInternetGatewayAsync(string internetGatewayId, string vpcId);
    }
}
