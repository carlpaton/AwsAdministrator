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
            InternetGateways = new List<DescribeInternetGatewayModel>();
            DhcpOptionsSets = new List<DescribeDhcpOptionsSetModel>();
            NetworkAcls = new List<DescribeNetworkAclsModel>();
            SecurityGroups = new List<DescribeSecurityGroupModel>();
        }

        [Display(Name = "Vpc Id")]
        public string VpcId { get; set; }

        [Display(Name = "IPv4 CidrBlock")]
        public string CidrBlock { get; set; }

        [Display(Name = "Owner")]
        public string OwnerId { get; set; }

        public string State { get; set; }
        public string Tenancy { get; set; }

        public List<DescribeSubnetModel> Subnets { get; set; }
        public List<DescribeRouteTableModel> RouteTables { get; set; }
        public List<DescribeInternetGatewayModel> InternetGateways { get; set; }
        public List<DescribeDhcpOptionsSetModel> DhcpOptionsSets { get; set; }
        public List<DescribeNetworkAclsModel> NetworkAcls { get; set; }
        public List<DescribeSecurityGroupModel> SecurityGroups { get; set; }
    }

    public class CreateDefaultVpcModel
    {
        public string AlertPrimary { get; set; }
    }
}
