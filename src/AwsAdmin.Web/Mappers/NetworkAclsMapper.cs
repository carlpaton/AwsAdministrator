using System.Collections.Generic;
using Amazon.EC2.Model;
using AwsAdmin.WebApp.Mappers.Interface;
using AwsAdmin.WebApp.Models;

namespace AwsAdmin.WebApp.Mappers
{
    public class NetworkAclsMapper : INetworkAclsMapper
    {
        public List<DescribeNetworkAclsModel> MapForDescribe(DescribeNetworkAclsResponse describeNetworkAclsResponse)
        {
            var model = new List<DescribeNetworkAclsModel>();

            foreach (var networkAcls in describeNetworkAclsResponse.NetworkAcls)
            {
                model.Add(new DescribeNetworkAclsModel()
                {
                    NetworkAclsId = networkAcls.NetworkAclId
                });
            }

            return model;
        }
    }
}
