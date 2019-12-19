using Amazon.EC2.Model;
using WebApp.Models;

namespace WebApp.Domain.Mappers.Interface
{
    public interface IDescribeVpcMapper
    {
        DescribeVpcModel MapForDescribe(DescribeVpcsResponse describeVpcsResponse);
    }
}
