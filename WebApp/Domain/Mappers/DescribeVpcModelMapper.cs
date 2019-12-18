using Amazon.EC2.Model;
using System.Linq;
using WebApp.Domain.Mappers.Interface;
using WebApp.Models;

namespace WebApp.Domain.Mappers
{
    public class DescribeVpcModelMapper : IDescribeVpcModelMapper
    {
        public DescribeVpcModel MapForDescribe(DescribeVpcsResponse describeVpcsResponse, DescribeSubnetsResponse describeSubnetsResponse) 
        {
            var viewModel = new DescribeVpcModel();

            var firstVpc = describeVpcsResponse.Vpcs.Count > 0
                ? describeVpcsResponse.Vpcs.Where(vpc => vpc.IsDefault).First()
                : new Amazon.EC2.Model.Vpc();

            viewModel.VpcId = firstVpc.VpcId;

            foreach (var subnet in describeSubnetsResponse.Subnets)
            {
                viewModel.Subnets.Add(new SubnetModel()
                {
                    SubnetId = subnet.SubnetId
                });
            }

            return viewModel;
        }
    }
}
