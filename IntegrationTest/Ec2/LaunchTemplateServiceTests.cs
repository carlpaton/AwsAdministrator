using Business.AmazonWebServices.Ec2;
using Business.AmazonWebServices.Ec2.Interface;
using Business.AmazonWebServices.Ec2.Mapping;
using Business.AmazonWebServices.Ec2.Model;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using businessAmazonWebServicesEc2Model = Business.AmazonWebServices.Ec2.Model;

namespace IntegrationTest.Ec2
{
    public class LaunchTemplateServiceTests
    {
        [Test]
        public async Task CreateLaunchTemplateAsync_should_create_and_return_launchTemplate()
        {
            // Arrange
            var createLaunchTemplateModel = new CreateLaunchTemplateModel
            {
                LaunchTemplateName = "LexiconServer",
                LaunchTemplateData = new businessAmazonWebServicesEc2Model.RequestLaunchTemplateData()
                {
                    EbsOptimized = false,
                    IamInstanceProfile = new businessAmazonWebServicesEc2Model.LaunchTemplateIamInstanceProfileSpecificationRequest()
                    {
                        Arn = "arn:aws:iam::032668436735:instance-profile/ecsInstanceRole"
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

            var client = new EnvironmentVariables().CloudComputeClient();
            var launchTemplateMapper = new LaunchTemplateMapper();
            ILaunchTemplateService classUnderTest = new LaunchTemplateService(client, launchTemplateMapper);

            // Act
            var response = await classUnderTest.CreateLaunchTemplateAsync(createLaunchTemplateModel);

            // Assert
            Assert.IsTrue(response.LaunchTemplate.LaunchTemplateId != null);
            Assert.IsTrue(response.LaunchTemplate.LaunchTemplateId.Length > 0);
        }

        [Test]
        public async Task DescribeLaunchTemplatesAsync_when_any_exist_should_describe_LaunchTemplates()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            var launchTemplateMapper = new LaunchTemplateMapper();
            ILaunchTemplateService classUnderTest = new LaunchTemplateService(client, launchTemplateMapper);

            // Act
            var response = await classUnderTest.DescribeLaunchTemplatesAsync();

            // Assert
            Assert.IsTrue(response.LaunchTemplates.Count > 0);
        }

        [Test]
        public async Task DeleteLaunchTemplateAsync_when_launchTemplateName_exists_should_delete()
        {
            // Arrange
            var launchTemplateId = "lt-01fb7549d798c4bfe";
            var client = new EnvironmentVariables().CloudComputeClient();
            var launchTemplateMapper = new LaunchTemplateMapper();
            ILaunchTemplateService classUnderTest = new LaunchTemplateService(client, launchTemplateMapper);

            // Act
            var response = await classUnderTest.DeleteLaunchTemplateAsync(launchTemplateId);

            // Assert
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
