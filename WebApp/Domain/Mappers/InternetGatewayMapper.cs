using System.Collections.Generic;
using Amazon.EC2.Model;
using WebApp.Domain.Mappers.Interface;
using WebApp.Models;

namespace WebApp.Domain.Mappers
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
