using System.Collections.Generic;
using Amazon.EC2.Model;
using AwsAdmin.WebApp.Mappers.Interface;
using AwsAdmin.WebApp.Models;

namespace AwsAdmin.WebApp.Mappers
{
    public class DescribeSubnetMapper : IDescribeSubnetMapper
    {
        public List<DescribeSubnetModel> MapForDescribe(DescribeSubnetsResponse describeSubnetsResponse)
        {
            var model = new List<DescribeSubnetModel>();

            foreach (var subnet in describeSubnetsResponse.Subnets)
            {
                model.Add(new DescribeSubnetModel()
                {
                    SubnetId = subnet.SubnetId
                });
            }

            return model;
        }
    }
}
