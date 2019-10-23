using System.Collections.Generic;

namespace Business.AmazonWebServices.Ec2.Model
{
    public class CreateLaunchTemplateModel
    {
        public RequestLaunchTemplateData LaunchTemplateData { get; set; }
    }

    public class RequestLaunchTemplateData
    {
        public bool EbsOptimized { get; set; }
        public LaunchTemplateIamInstanceProfileSpecificationRequest IamInstanceProfile { get; set; }
        public List<LaunchTemplateBlockDeviceMappingRequest> BlockDeviceMappings { get; set; }
        public List<LaunchTemplateInstanceNetworkInterfaceSpecificationRequest> NetworkInterfaces { get; set; }
        public string ImageId { get; set; }
        public InstanceType InstanceType { get; set; }
        public string KeyName { get; set; }
        public LaunchTemplatesMonitoringRequest Monitoring { get; set; }
        public LaunchTemplatePlacementRequest Placement { get; set; }
        public bool DisableApiTermination { get; set; }
        public ShutdownBehavior InstanceInitiatedShutdownBehavior { get; set; }
        public string UserData { get; set; }
        public List<LaunchTemplateTagSpecificationRequest> TagSpecifications { get; set; }
        public LaunchTemplateCpuOptionsRequest CpuOptions { get; set; }
        public LaunchTemplateCapacityReservationSpecificationRequest CapacityReservationSpecification { get; set; }
        public LaunchTemplateHibernationOptionsRequest HibernationOptions { get; set; }
    }

    public class LaunchTemplateIamInstanceProfileSpecificationRequest
    {
        public string Arn { get; set; }
    }

    public class LaunchTemplateBlockDeviceMappingRequest
    {
        public string DeviceName { get; set; }
        public LaunchTemplateEbsBlockDeviceRequest Ebs { get; set; }
    }

    public class LaunchTemplateEbsBlockDeviceRequest
    {
        public bool DeleteOnTermination { get; set; }
        public int VolumeSize { get; set; }
        public VolumeType VolumeType { get; set; }
    }

    public class VolumeType
    {
        public static readonly VolumeType Gp2;
    }

    public class LaunchTemplateInstanceNetworkInterfaceSpecificationRequest
    {
        public string Description { get; set; }
        public int DeviceIndex { get; set; }
        public List<InstanceIpv6AddressRequest> Ipv6Addresses { get; set; }
        public string NetworkInterfaceId { get; set; }
    }

    public class InstanceIpv6AddressRequest
    {
        public string Ipv6Address { get; set; }
    }

    public class InstanceType
    {
        public static readonly InstanceType M5aLarge;
    }

    public class LaunchTemplatesMonitoringRequest
    {
        public bool Enabled { get; set; }
    }

    public class LaunchTemplatePlacementRequest
    {
        public string GroupName { get; set; }
        public Tenancy Tenancy { get; set; }
    }

    public class Tenancy
    {
        public static readonly Tenancy Default;
    }

    public class ShutdownBehavior
    {
        public static readonly ShutdownBehavior Stop;
    }

    public class LaunchTemplateTagSpecificationRequest 
    {
        public ResourceType ResourceType { get; set; }
        public List<Tag> Tags { get; set; }
    }

    public class ResourceType
    {
        public static readonly ResourceType Instance;
    }

    public class Tag
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class LaunchTemplateCpuOptionsRequest 
    {
        public int CoreCount { get; set; }
        public int ThreadsPerCore { get; set; }
    }

    public class LaunchTemplateCapacityReservationSpecificationRequest 
    {
        public CapacityReservationPreference CapacityReservationPreference { get; set; }
    }

    public class CapacityReservationPreference
    {
        public static readonly CapacityReservationPreference Open;
    }

    public class LaunchTemplateHibernationOptionsRequest 
    {
        public bool Configured { get; set; }
    }
}
