using NUnit.Framework;
using System.Threading.Tasks;
using Amazon.AutoScaling;
using AwsAdmin.Application.Autoscaling;
using Amazon.AutoScaling.Model;
using AwsAdmin.Application.Ec2.Constants;
using System.Collections.Generic;
using AwsAdmin.Infrastructure.Services;

namespace IntegrationTest.AwsAdmin.Application.AwsAdmin.Application.Autoscaling
{
    public class LaunchConfigurationServiceTests
    {
        [Test]
        public async Task CreateLaunchConfigurationAsync_should_do_the_thing()
        {
            // Arrange
            var client = new AmazonAutoScalingClient();
            var classUnderTest = new LaunchConfigurationService(client);

            var base64EncodeService = new Base64EncodeService();
            var userData = @"#!/bin/bash
echo ECS_CLUSTER=lexicon-cluster >> /etc/ecs/ecs.config;echo ECS_BACKEND_HOST= >> /etc/ecs/ecs.config;";
            var userDataBase64Encoded = base64EncodeService.Encode(userData);

            var securityGroup = "sg-010638bf3e6a58e76";

            var request = new CreateLaunchConfigurationRequest
            {
                LaunchConfigurationName = "CreatedFromSDK",
                ImageId = Ec2Constants.AmiEcsLaunchTypeEc2,
                IamInstanceProfile = "ecsInstanceRole",
                KeyName = "carl-key-pair",
                UserData = userDataBase64Encoded,
                InstanceType = "m5a.large",
                InstanceMonitoring = new InstanceMonitoring() 
                {
                    Enabled = true
                },
                SecurityGroups = new List<string>() 
                {
                    securityGroup
                },
                BlockDeviceMappings = new List<BlockDeviceMapping>() 
                {
                    new BlockDeviceMapping()
                    {
                        DeviceName = "/dev/xvda",
                        Ebs = new Ebs()
                        {
                            DeleteOnTermination = true,
                            VolumeSize = 30,
                            VolumeType = "gp2"
                        }
                    }    
                },
                AssociatePublicIpAddress = true
            };

            // Act
            var response = await classUnderTest.CreateLaunchConfigurationAsync(request);

            // Assert
        }
    }
}
