using Amazon.EC2.Model;
using AwsAdmin.WebApp.Mappers.Interface;
using AwsAdmin.WebApp.Models;
using System.Collections.Generic;

namespace AwsAdmin.WebApp.Mappers
{
    public class DhcpOptionsSetsMapper : IDhcpOptionsSetsMapper
    {
        public List<DescribeDhcpOptionsSetModel> MapForDescribe(DescribeDhcpOptionsResponse describeDhcpOptionsResponse)
        {
            var model = new List<DescribeDhcpOptionsSetModel>();

            foreach (var dhcpOptionsSet in describeDhcpOptionsResponse.DhcpOptions)
            {
                model.Add(new DescribeDhcpOptionsSetModel()
                {
                    DhcpOptionsSetId = dhcpOptionsSet.DhcpOptionsId
                });
            }

            return model;
        }
    }
}
