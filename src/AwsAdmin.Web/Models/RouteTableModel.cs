using System.ComponentModel.DataAnnotations;

namespace AwsAdmin.WebApp.Models
{
    public class DescribeRouteTableModel
    {
        [Display(Name = "Route Table Id")]
        public string RouteTableId { get; set; }
    }
}
