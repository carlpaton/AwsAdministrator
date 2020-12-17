using Amazon.ECR.Model;
using System.Threading.Tasks;

namespace AwsAdmin.Application.Ecr.Interface
{
    public interface IImagesService
    {
        Task<ListImagesResponse> ListImagesAsync(string repositoryName);
    }
}
