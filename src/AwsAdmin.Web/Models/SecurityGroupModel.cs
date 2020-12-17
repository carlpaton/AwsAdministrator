using System.ComponentModel.DataAnnotations;

namespace AwsAdmin.WebApp.Models
{
    public class DescribeSecurityGroupModel
    {
        [Display(Name = "Security Group Id")]
        public string SecurityGroupId { get; set; }
    }
}
