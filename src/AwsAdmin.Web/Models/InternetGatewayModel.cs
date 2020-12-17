using System.ComponentModel.DataAnnotations;

namespace AwsAdmin.WebApp.Models
{
    public class DescribeInternetGatewayModel
    {
        [Display(Name = "Internet Gateway Id")]
        public string InternetGatewayId { get; set; }
    }
}
