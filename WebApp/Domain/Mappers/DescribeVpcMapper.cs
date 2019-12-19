using Amazon.EC2.Model;
using System.Linq;
using WebApp.Domain.Mappers.Interface;
using WebApp.Models;

namespace WebApp.Domain.Mappers
{
    public class DescribeVpcMapper : IDescribeVpcMapper
    {
        public DescribeVpcModel MapForDescribe(DescribeVpcsResponse describeVpcsResponse) 
        {
            var viewModel = new DescribeVpcModel();

            var firstVpc = describeVpcsResponse.Vpcs.Count > 0
                ? describeVpcsResponse.Vpcs.Where(vpc => vpc.IsDefault).First()
                : new Amazon.EC2.Model.Vpc();

            viewModel.VpcId = firstVpc.VpcId;

            return viewModel;
        }
    }
}
