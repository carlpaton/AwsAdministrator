using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace AwsAdmin.Application.Ec2.Interface
{
    public interface INetworkInterfaceService
    {
        Task<CreateNetworkInterfaceResponse> CreateNetworkInterfaceAsync(string subnetId);

        Task<DescribeNetworkInterfacesResponse> DescribeNetworkInterfacesAsync();
    }
}
