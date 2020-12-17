using Amazon.EC2.Model;
using AwsAdmin.WebApp.Models;
using System.Collections.Generic;

namespace AwsAdmin.WebApp.Mappers.Interface
{
    public interface ISecurityGroupMapper
    {
        List<DescribeSecurityGroupModel> MapForDescribe(DescribeSecurityGroupsResponse describeSecurityGroupsResponse);
    }
}
