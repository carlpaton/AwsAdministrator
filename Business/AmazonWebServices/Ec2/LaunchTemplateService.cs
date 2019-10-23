using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;
using Business.AmazonWebServices.Ec2.Mapping.Interface;
using Business.AmazonWebServices.Ec2.Model;

namespace Business.AmazonWebServices.Ec2
{
    public class LaunchTemplateService : ILaunchTemplateService
    {
        private readonly IAmazonEC2 _cloudComputeClient;
        private readonly ILaunchTemplateMapper _launchTemplateMapper;

        public LaunchTemplateService(IAmazonEC2 cloudComputeClient, ILaunchTemplateMapper launchTemplateMapper)
        {
            _cloudComputeClient = cloudComputeClient;
            _launchTemplateMapper = launchTemplateMapper;
        }

        public async Task<CreateLaunchTemplateResponse> CreateLaunchTemplateAsync(CreateLaunchTemplateModel model)
        {
            var request = _launchTemplateMapper.MapLaunchTemplate(model);
            var response = await _cloudComputeClient.CreateLaunchTemplateAsync(request);
            return response;
        }
    }
}
