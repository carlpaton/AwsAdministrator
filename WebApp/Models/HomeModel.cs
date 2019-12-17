using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ClientModel 
    {
        public AmazonECSClientModel AmazonECSClientModel { get; set; }
        public AmazonEC2ClientModel AmazonEC2ClientModel { get; set; }
        public AmazonECRClientModel AmazonECRClientModel { get; set; }
        public string AwsAccessKeyId { get; set; }
        public string AwsSecretAccessKey { get; set; }
    }

    public class AmazonECSClientModel : BaseModel
    { 
    }

    public class AmazonEC2ClientModel : BaseModel
    {
    }

    public class AmazonECRClientModel : BaseModel
    {
    }

    public class BaseModel
    {
        [Display(Name = "Service Name")]
        public string AuthenticationServiceName { get; set; }
        [Display(Name = "Region")]
        public string RegionEndpointSystemName { get; set; }
    }
}
