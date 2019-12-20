using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class DescribeInternetGatewayModel
    {
        [Display(Name = "Internet Gateway Id")]
        public string InternetGatewayId { get; set; }
    }
}
