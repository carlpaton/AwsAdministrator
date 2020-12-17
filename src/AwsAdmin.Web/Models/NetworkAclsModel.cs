using System.ComponentModel.DataAnnotations;

namespace AwsAdmin.WebApp.Models
{
    public class DescribeNetworkAclsModel
    {
        [Display(Name = "Network Acls Id")]
        public string NetworkAclsId { get; set; }
    }
}
