using System.ComponentModel.DataAnnotations;

namespace AwsAdmin.WebApp.Models
{
    public class DescribeSubnetModel
    {
        [Display(Name = "Subnet Id")]
        public string SubnetId { get; set; }
    }
}
