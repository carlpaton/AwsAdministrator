using Amazon.EC2.Model;
using Business.AmazonWebServices.Ec2.Mapping;
using NUnit.Framework;
using FluentAssertions;
using Business.AmazonWebServices.Ec2.Model;
using businessAmazonWebServicesEc2Model = Business.AmazonWebServices.Ec2.Model;
using System.Collections.Generic;

namespace UnitTest.Business.AmazonWebServices.Ec2.Mapper
{
    public class LaunchTemplateMapperTests
    {
        [Test]
        public void MapLaunchTemplate_given_valid_CreateLaunchTemplateModel_should_map_to_CreateLaunchTemplateRequest()
        {
            // Arrange
            var createLaunchTemplateModel = new CreateLaunchTemplateModel 
            {
                LaunchTemplateData = new businessAmazonWebServicesEc2Model.RequestLaunchTemplateData() 
                {
                    EbsOptimized = false,
                    IamInstanceProfile = new businessAmazonWebServicesEc2Model.LaunchTemplateIamInstanceProfileSpecificationRequest() 
                    {
                        Arn = "arn:aws:iam::000000000000:instance-profile/ecsInstanceRole"
                    },
                    BlockDeviceMappings = new List<businessAmazonWebServicesEc2Model.LaunchTemplateBlockDeviceMappingRequest>() 
                    {
                        new businessAmazonWebServicesEc2Model.LaunchTemplateBlockDeviceMappingRequest()
                        {
                            DeviceName = "/dev/xvda",
                            Ebs = new businessAmazonWebServicesEc2Model.LaunchTemplateEbsBlockDeviceRequest()
                            {
                                DeleteOnTermination = true,
                                VolumeSize = 30,
                                VolumeType = VolumeType.Gp2
                            }
                        },
                        new businessAmazonWebServicesEc2Model.LaunchTemplateBlockDeviceMappingRequest()
                        {
                            DeviceName = "/dev/xvdcz",
                            Ebs = new businessAmazonWebServicesEc2Model.LaunchTemplateEbsBlockDeviceRequest()
                            {
                                DeleteOnTermination = true,
                                VolumeSize = 30,
                                VolumeType = VolumeType.Gp2
                            }
                        }
                    },
                    NetworkInterfaces = new List<businessAmazonWebServicesEc2Model.LaunchTemplateInstanceNetworkInterfaceSpecificationRequest>() 
                    {
                        new businessAmazonWebServicesEc2Model.LaunchTemplateInstanceNetworkInterfaceSpecificationRequest()
                        {
                            Description = "",
                            DeviceIndex = 0,
                            Ipv6Addresses = new List<businessAmazonWebServicesEc2Model.InstanceIpv6AddressRequest>(),
                            NetworkInterfaceId = "eni-002e4968b147b7dcc"
                        }
                    },
                    ImageId = "ami-061f60917a06a83a5",
                    InstanceType = InstanceType.M5aLarge,
                    KeyName = "carl-key-pair",
                    Monitoring = new businessAmazonWebServicesEc2Model.LaunchTemplatesMonitoringRequest() 
                    {
                        Enabled = true
                    },
                    Placement = new businessAmazonWebServicesEc2Model.LaunchTemplatePlacementRequest() 
                    {
                        GroupName = "",
                        Tenancy = Tenancy.Default
                    },
                    DisableApiTermination = false,
                    InstanceInitiatedShutdownBehavior = ShutdownBehavior.Stop,
                    UserData = "IyEvYmluL2Jhc2gKZWNobyBFQ1NfQ0xVU1RFUj1sZXhpY29uLWNsdXN0ZXIgPj4gL2V0Yy9lY3MvZWNzLmNvbmZpZztlY2hvIEVDU19CQUNLRU5EX0hPU1Q9ID4+IC9ldGMvZWNzL2Vjcy5jb25maWc7",
                    TagSpecifications = new List<businessAmazonWebServicesEc2Model.LaunchTemplateTagSpecificationRequest>() 
                    {
                        new businessAmazonWebServicesEc2Model.LaunchTemplateTagSpecificationRequest()
                        {
                            ResourceType = ResourceType.Instance,
                            Tags = new List<businessAmazonWebServicesEc2Model.Tag>()
                            {
                                new businessAmazonWebServicesEc2Model.Tag()
                                {
                                    Key = "Description",
                                    Value = "lexicon"
                                }
                            }
                        }
                    },
                    CpuOptions = new businessAmazonWebServicesEc2Model.LaunchTemplateCpuOptionsRequest() 
                    { 
                        CoreCount = 1,
                        ThreadsPerCore = 2
                    },
                    CapacityReservationSpecification = new businessAmazonWebServicesEc2Model.LaunchTemplateCapacityReservationSpecificationRequest() 
                    {
                        CapacityReservationPreference = CapacityReservationPreference.Open
                    },
                    HibernationOptions = new businessAmazonWebServicesEc2Model.LaunchTemplateHibernationOptionsRequest() 
                    { 
                        Configured = false    
                    }
                }
            };
            var expectedModel = new CreateLaunchTemplateRequest
            {
                LaunchTemplateData = new Amazon.EC2.Model.RequestLaunchTemplateData()
                {
                    EbsOptimized = false,
                    IamInstanceProfile = new Amazon.EC2.Model.LaunchTemplateIamInstanceProfileSpecificationRequest()
                    {
                        Arn = "arn:aws:iam::000000000000:instance-profile/ecsInstanceRole"
                    },
                    BlockDeviceMappings = new List<Amazon.EC2.Model.LaunchTemplateBlockDeviceMappingRequest>()
                    {
                        new Amazon.EC2.Model.LaunchTemplateBlockDeviceMappingRequest()
                        {
                            DeviceName = "/dev/xvda",
                            Ebs = new Amazon.EC2.Model.LaunchTemplateEbsBlockDeviceRequest()
                            {
                                DeleteOnTermination = true,
                                VolumeSize = 30,
                                VolumeType = Amazon.EC2.VolumeType.Gp2
                            }
                        },
                        new Amazon.EC2.Model.LaunchTemplateBlockDeviceMappingRequest()
                        {
                            DeviceName = "/dev/xvdcz",
                            Ebs = new Amazon.EC2.Model.LaunchTemplateEbsBlockDeviceRequest()
                            {
                                DeleteOnTermination = true,
                                VolumeSize = 30,
                                VolumeType = Amazon.EC2.VolumeType.Gp2
                            }
                        }
                    },
                    NetworkInterfaces = new List<Amazon.EC2.Model.LaunchTemplateInstanceNetworkInterfaceSpecificationRequest>()
                    {
                        new Amazon.EC2.Model.LaunchTemplateInstanceNetworkInterfaceSpecificationRequest()
                        {
                            Description = "",
                            DeviceIndex = 0,
                            Ipv6Addresses = new List<Amazon.EC2.Model.InstanceIpv6AddressRequest>(),
                            NetworkInterfaceId = "eni-002e4968b147b7dcc"
                        }
                    },
                    ImageId = "ami-061f60917a06a83a5",
                    InstanceType = Amazon.EC2.InstanceType.M5aLarge,
                    KeyName = "carl-key-pair",
                    Monitoring = new Amazon.EC2.Model.LaunchTemplatesMonitoringRequest()
                    {
                        Enabled = true
                    },
                    Placement = new Amazon.EC2.Model.LaunchTemplatePlacementRequest()
                    {
                        GroupName = "",
                        Tenancy = Amazon.EC2.Tenancy.Default
                    },
                    DisableApiTermination = false,
                    InstanceInitiatedShutdownBehavior = Amazon.EC2.ShutdownBehavior.Stop,
                    UserData = "IyEvYmluL2Jhc2gKZWNobyBFQ1NfQ0xVU1RFUj1sZXhpY29uLWNsdXN0ZXIgPj4gL2V0Yy9lY3MvZWNzLmNvbmZpZztlY2hvIEVDU19CQUNLRU5EX0hPU1Q9ID4+IC9ldGMvZWNzL2Vjcy5jb25maWc7",
                    TagSpecifications = new List<Amazon.EC2.Model.LaunchTemplateTagSpecificationRequest>()
                    {
                        new Amazon.EC2.Model.LaunchTemplateTagSpecificationRequest()
                        {
                            ResourceType = Amazon.EC2.ResourceType.Instance,
                            Tags = new List<Amazon.EC2.Model.Tag>()
                            {
                                new Amazon.EC2.Model.Tag()
                                {
                                    Key = "Description",
                                    Value = "lexicon"
                                }
                            }
                        }
                    },
                    CpuOptions = new Amazon.EC2.Model.LaunchTemplateCpuOptionsRequest()
                    {
                        CoreCount = 1,
                        ThreadsPerCore = 2
                    },
                    CapacityReservationSpecification = new Amazon.EC2.Model.LaunchTemplateCapacityReservationSpecificationRequest()
                    {
                        CapacityReservationPreference = Amazon.EC2.CapacityReservationPreference.Open
                    },
                    HibernationOptions = new Amazon.EC2.Model.LaunchTemplateHibernationOptionsRequest()
                    {
                        Configured = false
                    }
                }
            };

            // Act
            var actual = new LaunchTemplateMapper().MapLaunchTemplate(createLaunchTemplateModel);

            // Assert
            actual.Should().BeEquivalentTo(expectedModel);
        }
    }
}
