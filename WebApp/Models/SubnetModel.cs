using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SubnetModel
    {
        [Display(Name = "Subnet Id")]
        public string SubnetId { get; set; }
    }
}
