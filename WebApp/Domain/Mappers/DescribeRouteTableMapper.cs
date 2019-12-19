using System.Collections.Generic;
using Amazon.EC2.Model;
using WebApp.Domain.Mappers.Interface;
using WebApp.Models;

namespace WebApp.Domain.Mappers
{
    public class DescribeRouteTableMapper : IDescribeRouteTableMapper
    {
        public List<DescribeRouteTableModel> MapForDescribe(DescribeRouteTablesResponse describeRouteTablesResponse)
        {
            var model = new List<DescribeRouteTableModel>();

            foreach (var routeTable in describeRouteTablesResponse.RouteTables)
            {
                model.Add(new DescribeRouteTableModel()
                {
                    RouteTableId = routeTable.RouteTableId
                });
            }

            return model;
        }
    }
}
