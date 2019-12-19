using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class DescribeVpcModel
    {
        public DescribeVpcModel() 
        {
            Subnets = new List<DescribeSubnetModel>();
            RouteTables = new List<DescribeRouteTableModel>();
        }

        [Display(Name = "Vpc Id")]
        public string VpcId { get; set; }

        public List<DescribeSubnetModel> Subnets { get; set; }
        public List<DescribeRouteTableModel> RouteTables { get; set; }
    }

    public class CreateDefaultVpcModel
    {
        public string AlertPrimary { get; set; }
    }
}
