using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace AwsAdmin.Application.Ec2.Interface
{
    public interface IInstanceService
    {
        Task<RunInstancesResponse> RunInstancesAsync(string launchTemplateId);
        Task<DescribeInstancesResponse> DescribeInstancesAsync();
    }
}
