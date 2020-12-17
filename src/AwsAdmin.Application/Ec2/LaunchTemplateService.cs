using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using AwsAdmin.Application.Ec2.Interface;
using AwsAdmin.Application.Ec2.Mapping.Interface;
using AwsAdmin.Application.Ec2.Model;

namespace AwsAdmin.Application.Ec2
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

        public async Task<DeleteLaunchTemplateResponse> DeleteLaunchTemplateAsync(string launchTemplateId)
        {
            var request = new DeleteLaunchTemplateRequest
            {
               LaunchTemplateId = launchTemplateId
            };

            var response = await _cloudComputeClient.DeleteLaunchTemplateAsync(request);
            return response;
        }

        public async Task<DescribeLaunchTemplatesResponse> DescribeLaunchTemplatesAsync()
        {
            var request = new DescribeLaunchTemplatesRequest();
            var response = await _cloudComputeClient.DescribeLaunchTemplatesAsync(request);
            return response;
        }

        public async Task<DescribeLaunchTemplateVersionsResponse> DescribeLaunchTemplateVersionsAsync(string launchTemplateId)
        {
            var request = new DescribeLaunchTemplateVersionsRequest
            {
                LaunchTemplateId = launchTemplateId
            };

            return await _cloudComputeClient.DescribeLaunchTemplateVersionsAsync(request);
        }
    }
}