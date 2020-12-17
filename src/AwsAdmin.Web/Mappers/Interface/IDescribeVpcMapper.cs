using Amazon.EC2.Model;
using AwsAdmin.WebApp.Models;

namespace AwsAdmin.WebApp.Mappers.Interface
{
    public interface IDescribeVpcMapper
    {
        DescribeVpcModel MapForDescribe(DescribeVpcsResponse describeVpcsResponse);
    }
}
