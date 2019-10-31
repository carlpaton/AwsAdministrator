using Business.AmazonWebServices.Ec2;
using Business.AmazonWebServices.Ec2.Constants;
using Business.AmazonWebServices.Ec2.Interface;
using Business.AmazonWebServices.Ec2.Mapping;
using Business.AmazonWebServices.Ec2.Model;
using Common;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using businessAmazonWebServicesEc2Model = Business.AmazonWebServices.Ec2.Model;

namespace IntegrationTest.Ec2
{
    public class LaunchTemplateServiceTests
    {
        [Test]
        public async Task CreateLaunchTemplateAsync_should_create_and_return_launchTemplate()
        {
            var client = new EnvironmentVariables().CloudComputeClient();
            var launchTemplateMapper = new LaunchTemplateMapper();
            var base64EncodeService = new Base64EncodeService();

            var imageId = Ec2Constants.AmiEcsLaunchTypeEc2;
            var networkInterfaceId = "eni-0997d795c171fe409";
            var arn = "arn:aws:iam::032668436735:instance-profile/ecsInstanceRole";
            var launchTemplateName = "CreatedFromSDK"; //LexiconServer;
            var keyName = "carl-key-pair";
            var clusterName = "lexicon-cluster";

            var userData = @"#!/bin/bash
cat <<'EOF' >> /etc/ecs/ecs.config
echo ECS_CLUSTER=lexicon-cluster
echo ECS_BACKEND_HOST=
EOF";

            var userDataBase64Encoded = base64EncodeService.Encode(userData);

            // Arrange
            var createLaunchTemplateModel = new CreateLaunchTemplateModel
            {
                LaunchTemplateName = launchTemplateName,
                LaunchTemplateData = new businessAmazonWebServicesEc2Model.RequestLaunchTemplateData()
                {
                    EbsOptimized = false,
                    IamInstanceProfile = new businessAmazonWebServicesEc2Model.LaunchTemplateIamInstanceProfileSpecificationRequest()
                    {
                        Arn = arn
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
                            NetworkInterfaceId = networkInterfaceId
                        }
                    },
                    ImageId = imageId,
                    InstanceType = InstanceType.M5aLarge,
                    KeyName = keyName,
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
                    UserData = userDataBase64Encoded,
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

        [Test]
        public async Task DescribeLaunchTemplateVersionsAsync_when_exists_should_describe_launchTemplate()
        {
            // Arrange
            var launchTemplateId = "lt-0fcbe2e67412b3f18";
            var client = new EnvironmentVariables().CloudComputeClient();
            var launchTemplateMapper = new LaunchTemplateMapper();
            ILaunchTemplateService classUnderTest = new LaunchTemplateService(client, launchTemplateMapper);

            // Act
            var response = await classUnderTest.DescribeLaunchTemplateVersionsAsync(launchTemplateId);

            // Assert
            Assert.IsTrue(response.LaunchTemplateVersions.Count > 0);

            // Dump response
            new ResponseToJsonFile().Go("LaunchTemplate_CreatedFromSDK", response.LaunchTemplateVersions.First());
        }
    }
}
