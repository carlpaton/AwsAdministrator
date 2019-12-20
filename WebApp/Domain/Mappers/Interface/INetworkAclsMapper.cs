using Amazon.EC2.Model;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Domain.Mappers.Interface
{
    public interface INetworkAclsMapper
    {
        List<DescribeNetworkAclsModel> MapForDescribe(DescribeNetworkAclsResponse describeNetworkAclsResponse);
    }
}
