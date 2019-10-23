using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Model;

namespace Business.AmazonWebServices.Ec2.Mapping.Interface
{
    public interface ILaunchTemplateMapper
    {
        CreateLaunchTemplateRequest MapLaunchTemplate(CreateLaunchTemplateModel model);
    }
}
