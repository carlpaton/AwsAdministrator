using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2.Interface
{
    public interface ISecurityGroupService
    {
        Task<DescribeSecurityGroupsResponse> DescribeSecurityGroupsAsync();
    }
}
