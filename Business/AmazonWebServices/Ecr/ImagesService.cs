using System.Threading.Tasks;
using Amazon.ECR;
using Amazon.ECR.Model;
using Business.AmazonWebServices.Ecr.Interface;

namespace Business.AmazonWebServices.Ecr
{
    public class ImagesService : IImagesService
    {
        private readonly IAmazonECR _containerRegistryClient;

        public ImagesService(IAmazonECR containerRegistryClient)
        {
            _containerRegistryClient = containerRegistryClient;
        }

        public async Task<ListImagesResponse> ListImagesAsync(string repositoryName)
        {
            var request = new ListImagesRequest
            {
                RepositoryName = repositoryName
            };

            var response = await _containerRegistryClient.ListImagesAsync(request);
            return response;
        }
    }
}
