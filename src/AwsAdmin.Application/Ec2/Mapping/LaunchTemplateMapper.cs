using Amazon.EC2.Model;
using AwsAdmin.Application.Ec2.Mapping.Interface;
using AwsAdmin.Application.Ec2.Model;
using AutoMapper;
using businessAmazonWebServicesEc2Model = AwsAdmin.Application.Ec2.Model;

namespace AwsAdmin.Application.Ec2.Mapping
{
    public class LaunchTemplateMapper : ILaunchTemplateMapper
    {
        public CreateLaunchTemplateRequest MapLaunchTemplate(CreateLaunchTemplateModel model) 
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<CreateLaunchTemplateModel, CreateLaunchTemplateRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.RequestLaunchTemplateData, Amazon.EC2.Model.RequestLaunchTemplateData>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.LaunchTemplateIamInstanceProfileSpecificationRequest, Amazon.EC2.Model.LaunchTemplateIamInstanceProfileSpecificationRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.LaunchTemplateBlockDeviceMappingRequest, Amazon.EC2.Model.LaunchTemplateBlockDeviceMappingRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.LaunchTemplateInstanceNetworkInterfaceSpecificationRequest, Amazon.EC2.Model.LaunchTemplateInstanceNetworkInterfaceSpecificationRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.InstanceType, Amazon.EC2.InstanceType>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.LaunchTemplatesMonitoringRequest, Amazon.EC2.Model.LaunchTemplatesMonitoringRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.LaunchTemplatePlacementRequest, Amazon.EC2.Model.LaunchTemplatePlacementRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.ShutdownBehavior, Amazon.EC2.ShutdownBehavior>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.LaunchTemplateTagSpecificationRequest, Amazon.EC2.Model.LaunchTemplateTagSpecificationRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.LaunchTemplateCpuOptionsRequest, Amazon.EC2.Model.LaunchTemplateCpuOptionsRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.LaunchTemplateCapacityReservationSpecificationRequest, Amazon.EC2.Model.LaunchTemplateCapacityReservationSpecificationRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.LaunchTemplateHibernationOptionsRequest, Amazon.EC2.Model.LaunchTemplateHibernationOptionsRequest>();

                cfg.CreateMap<businessAmazonWebServicesEc2Model.LaunchTemplateEbsBlockDeviceRequest, Amazon.EC2.Model.LaunchTemplateEbsBlockDeviceRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.VolumeType, Amazon.EC2.VolumeType>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.InstanceIpv6AddressRequest, Amazon.EC2.Model.InstanceIpv6AddressRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.InstanceType, Amazon.EC2.InstanceType>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.Tenancy, Amazon.EC2.Tenancy>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.ResourceType, Amazon.EC2.ResourceType>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.Tag, Amazon.EC2.Model.Tag>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.LaunchTemplateCpuOptionsRequest, Amazon.EC2.Model.LaunchTemplateCpuOptionsRequest>();
                cfg.CreateMap<businessAmazonWebServicesEc2Model.CapacityReservationPreference, Amazon.EC2.CapacityReservationPreference>();
            });

            var mapper = new Mapper(configuration);
            var mappedObject = mapper.Map<CreateLaunchTemplateModel, CreateLaunchTemplateRequest>(model);
            HackInStaticFields(mappedObject, model);

            return mappedObject;
        }

        /// <summary>
        /// This could be changed to check for the `AwsAdmin.Application.Ec2.Model.VolumeType -> Gp2` first and then map based on a manual `if this, return this`
        /// This is however equally crap - there must be a way to map these static fields with automapper -_-
        /// </summary>
        /// <param name="mappedObject"></param>
        /// <param name="model"></param>
        private void HackInStaticFields(CreateLaunchTemplateRequest mappedObject, CreateLaunchTemplateModel model)
        {
            //Amazon.EC2.VolumeType.Gp2
            var pos = 0;
            foreach (var blockDeviceMappings in model.LaunchTemplateData.BlockDeviceMappings)
            {
                mappedObject.LaunchTemplateData.BlockDeviceMappings[pos].Ebs.VolumeType = Amazon.EC2.VolumeType.Gp2;
                pos++;
            }

            //Amazon.EC2.ResourceType.Instance
            pos = 0;
            foreach (var tagSpecification in model.LaunchTemplateData.TagSpecifications)
            {
                mappedObject.LaunchTemplateData.TagSpecifications[pos].ResourceType = Amazon.EC2.ResourceType.Instance;
                pos++;
            }

            //Amazon.EC2.CapacityReservationPreference.Open
            mappedObject.LaunchTemplateData.CapacityReservationSpecification.CapacityReservationPreference = Amazon.EC2.CapacityReservationPreference.Open;

            //Amazon.EC2.ShutdownBehavior.Stop
            mappedObject.LaunchTemplateData.InstanceInitiatedShutdownBehavior = Amazon.EC2.ShutdownBehavior.Stop;

            //Amazon.EC2.InstanceType
            mappedObject.LaunchTemplateData.InstanceType = Amazon.EC2.InstanceType.M5aLarge;

            //Amazon.EC2.Tenancy.Default
            mappedObject.LaunchTemplateData.Placement.Tenancy = Amazon.EC2.Tenancy.Default;
        }
    }
}
