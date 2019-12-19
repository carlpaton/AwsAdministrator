using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class DescribeRouteTableModel
    {
        [Display(Name = "Route Table Id")]
        public string RouteTableId { get; set; }
    }
}
