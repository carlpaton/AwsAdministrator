using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using AwsAdmin.Application.Ec2.Interface;

namespace AwsAdmin.Application.Ec2
{
    public class InstanceService : IInstanceService
    {
        private readonly IAmazonEC2 _cloudComputeClient;

        public InstanceService(IAmazonEC2 cloudComputeClient)
        {
            _cloudComputeClient = cloudComputeClient;
        }

        public async Task<DescribeInstancesResponse> DescribeInstancesAsync()
        {
            var request = new DescribeInstancesRequest();
            var response = await _cloudComputeClient.DescribeInstancesAsync(request);
            return response;
        }

        public async Task<RunInstancesResponse> RunInstancesAsync(string launchTemplateId)
        {
            var request = new RunInstancesRequest
            {
                LaunchTemplate = new LaunchTemplateSpecification()
                {
                    LaunchTemplateId = launchTemplateId
                },
                MinCount = 1,
                MaxCount = 1
            };

            var response = await _cloudComputeClient.RunInstancesAsync(request);
            return response;
        }
    }
}
