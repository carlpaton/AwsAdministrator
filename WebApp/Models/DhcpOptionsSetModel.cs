using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class DescribeDhcpOptionsSetModel
    {
        [Display(Name = "Dhcp Options Set Id")]
        public string DhcpOptionsSetId { get; set; }
    }
}
