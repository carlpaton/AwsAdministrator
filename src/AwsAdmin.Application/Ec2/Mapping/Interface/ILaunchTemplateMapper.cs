using Amazon.EC2.Model;
using AwsAdmin.Application.Ec2.Model;

namespace AwsAdmin.Application.Ec2.Mapping.Interface
{
    public interface ILaunchTemplateMapper
    {
        CreateLaunchTemplateRequest MapLaunchTemplate(CreateLaunchTemplateModel model);
    }
}
