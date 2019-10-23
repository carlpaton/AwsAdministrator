using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2.Interface
{
    public interface ILaunchTemplateService
    {
        Task<CreateLaunchTemplateResponse> CreateLaunchTemplateAsync(Model.CreateLaunchTemplateModel model);

        Task<DescribeLaunchTemplatesResponse> DescribeLaunchTemplatesAsync();

        Task<DeleteLaunchTemplateResponse> DeleteLaunchTemplateAsync(string launchTemplateId);

        //DeleteLaunchTemplateVersionsAsync
    }
}
