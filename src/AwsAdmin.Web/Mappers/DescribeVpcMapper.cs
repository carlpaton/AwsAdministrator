using Amazon.EC2.Model;
using AwsAdmin.WebApp.Mappers.Interface;
using AwsAdmin.WebApp.Models;
using System.Linq;

namespace AwsAdmin.WebApp.Mappers
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
            viewModel.State = firstVpc.State.ToString();
            viewModel.CidrBlock = firstVpc.CidrBlock;
            viewModel.Tenancy = firstVpc.InstanceTenancy.ToString();
            viewModel.OwnerId = firstVpc.OwnerId;

            return viewModel;
        }
    }
}
