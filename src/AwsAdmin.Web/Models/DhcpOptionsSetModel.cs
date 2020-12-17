using System.ComponentModel.DataAnnotations;

namespace AwsAdmin.WebApp.Models
{
    public class DescribeDhcpOptionsSetModel
    {
        [Display(Name = "Dhcp Options Set Id")]
        public string DhcpOptionsSetId { get; set; }
    }
}
