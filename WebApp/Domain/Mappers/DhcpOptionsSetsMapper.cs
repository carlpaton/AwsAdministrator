using Amazon.EC2.Model;
using System.Collections.Generic;
using WebApp.Domain.Mappers.Interface;
using WebApp.Models;

namespace WebApp.Domain.Mappers
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
