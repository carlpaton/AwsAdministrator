using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace AwsAdmin.Application.Ec2.Interface
{
    public interface INetworkAclsService
    {
        Task<DescribeNetworkAclsResponse> DescribeNetworkAclsAsync();
    }
}
