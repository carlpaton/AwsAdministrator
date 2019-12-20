using Amazon.EC2.Model;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Domain.Mappers.Interface
{
    public interface ISecurityGroupMapper
    {
        List<DescribeSecurityGroupModel> MapForDescribe(DescribeSecurityGroupsResponse describeSecurityGroupsResponse);
    }
}
