using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class DescribeNetworkAclsModel
    {
        [Display(Name = "Network Acls Id")]
        public string NetworkAclsId { get; set; }
    }
}
