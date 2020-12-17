using System.Collections.Generic;
using Amazon.EC2.Model;
using AwsAdmin.WebApp.Mappers.Interface;
using AwsAdmin.WebApp.Models;

namespace AwsAdmin.WebApp.Mappers
{
    public class SecurityGroupMapper : ISecurityGroupMapper
    {
        public List<DescribeSecurityGroupModel> MapForDescribe(DescribeSecurityGroupsResponse describeSecurityGroupsResponse)
        {
            var model = new List<DescribeSecurityGroupModel>();

            foreach (var securityGroup in describeSecurityGroupsResponse.SecurityGroups)
            {
                model.Add(new DescribeSecurityGroupModel()
                {
                    SecurityGroupId = securityGroup.GroupId
                });
            }

            return model;
        }
    }
}
