using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class DescribeSubnetModel
    {
        [Display(Name = "Subnet Id")]
        public string SubnetId { get; set; }
    }
}
