using Amazon.EC2.Model;
using AwsAdmin.WebApp.Models;
using System.Collections.Generic;

namespace AwsAdmin.WebApp.Mappers.Interface
{
    public interface IDescribeSubnetMapper
    {
        List<DescribeSubnetModel> MapForDescribe(DescribeSubnetsResponse describeSubnetsResponse);
    }
}
