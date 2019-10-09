﻿using Amazon.EC2;
using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Interface;
using System.Threading.Tasks;

namespace Business.AmazonWebServices.Ec2
{
    public class VpcService : IVpcService
    {
        private readonly IAmazonEC2 _amazonEC2Client;

        public VpcService(IAmazonEC2 amazonEC2Client)
        {
            _amazonEC2Client = amazonEC2Client;
        }

        public async Task<CreateVpcResponse> CreateVpcAsync(string cidrBlock)
        {
            var request = new CreateVpcRequest(cidrBlock);
            var response = await _amazonEC2Client.CreateVpcAsync(request);
            return response;
        }

        public async Task<DescribeVpcsResponse> DescribeVpcsAsync()
        {
            var response = await _amazonEC2Client.DescribeVpcsAsync();
            return response;
        }

        public async Task<DeleteVpcResponse> DeleteVpcAsync(string vpcId)
        {
            var request = new DeleteVpcRequest(vpcId);
            var response = await _amazonEC2Client.DeleteVpcAsync(request);
            return response;
        }
    }
}
