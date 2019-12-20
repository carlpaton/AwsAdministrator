using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class DescribeSecurityGroupModel
    {
        [Display(Name = "Security Group Id")]
        public string SecurityGroupId { get; set; }
    }
}
