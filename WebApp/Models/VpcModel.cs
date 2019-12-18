using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class DescribeVpcModel
    {
        public DescribeVpcModel() 
        {
            Subnets = new List<SubnetModel>();
        }

        [Display(Name = "Vpc Id")]
        public string VpcId { get; set; }
        public List<SubnetModel> Subnets { get; set; }
}

    public class CreateDefaultVpcModel
    {
        public string AlertPrimary { get; set; }
    }
}
