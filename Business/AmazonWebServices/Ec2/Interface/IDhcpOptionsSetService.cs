using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2.Interface
{
    public interface IDhcpOptionsSetService
    {
        Task<DescribeDhcpOptionsResponse> DescribeDhcpOptionsAsync();

        /// <summary>
        /// `DhcpOptionsSet` are not deleted when a VPC is deleted, they need to be manually deleted if no longer needed. 
        /// </summary>
        /// <param name="dhcpOptionsId"></param>
        /// <returns></returns>
        Task<DeleteDhcpOptionsResponse> DeleteDhcpOptionsAsync(string dhcpOptionsId);
    }
}
