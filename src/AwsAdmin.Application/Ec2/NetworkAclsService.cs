﻿using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using AwsAdmin.Application.Ec2.Interface;

namespace AwsAdmin.Application.Ec2
{
    public class NetworkAclsService : INetworkAclsService
    {
        private readonly IAmazonEC2 _cloudComputeClient;

        public NetworkAclsService(IAmazonEC2 cloudComputeClient)
        {
            _cloudComputeClient = cloudComputeClient;
        }

        public async Task<DescribeNetworkAclsResponse> DescribeNetworkAclsAsync()
        {
            var response = await _cloudComputeClient.DescribeNetworkAclsAsync();
            return response;
        }
    }
}
