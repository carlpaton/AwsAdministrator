using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2.Interface
{
    public interface IRunInstanceService
    {
        Task<RunInstancesResponse> RunInstancesAsync(string launchTemplateId);
    }
}
