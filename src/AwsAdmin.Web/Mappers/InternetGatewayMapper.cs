using System.Collections.Generic;
using Amazon.EC2.Model;
using AwsAdmin.WebApp.Mappers.Interface;
using AwsAdmin.WebApp.Models;

namespace AwsAdmin.WebApp.Mappers
{
    public class InternetGatewayMapper : IInternetGatewayMapper
    {
        public List<DescribeInternetGatewayModel> MapForDescribe(DescribeInternetGatewaysResponse describeInternetGatewaysResponse)
        {
            var model = new List<DescribeInternetGatewayModel>();

            foreach (var internetGateway in describeInternetGatewaysResponse.InternetGateways)
            {
                model.Add(new DescribeInternetGatewayModel()
                {
                    InternetGatewayId = internetGateway.InternetGatewayId
                });
            }

            return model;
        }
    }
}
