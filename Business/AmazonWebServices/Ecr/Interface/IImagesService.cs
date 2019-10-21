using Amazon.ECR.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ecr.Interface
{
    public interface IImagesService
    {
        Task<ListImagesResponse> ListImagesAsync(string repositoryName);
    }
}
