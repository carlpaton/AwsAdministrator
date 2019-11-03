using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2.Interface
{
    /// <summary>
    /// Allocates an Elastic IP address to your AWS account. After you allocate the Elastic
    /// IP address you can associate it with an instance or network interface.
    /// </summary>
    public interface IElasticIpService
    {
        Task<AllocateAddressResponse> AllocateAddressAsync();

        Task<AssociateAddressResponse> AssociateAddressAsync(string instanceId, string publicIp);
    }
}
