using Amazon.EC2.Model;
using WebApp.Models;

namespace WebApp.Domain.Mappers.Interface
{
    public interface IDescribeVpcModelMapper
    {
        DescribeVpcModel MapForDescribe(DescribeVpcsResponse describeVpcsResponse, DescribeSubnetsResponse describeSubnetsResponse);
    }
}
