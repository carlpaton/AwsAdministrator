﻿using Amazon.EC2;
using Business.AmazonWebServices.Ec2;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest
{
    public class SecurityGroupServiceTests
    {
        [SetUp]
        public void Setup()
        {
            new EnvironmentVariables();
        }

        [Test]
        public async Task DescribeVpcsAsync_when_any_exist_should_describe_vpcs()
        {
            // Arrange
            var client = new AmazonEC2Client();
            var classUnderTest = new SecurityGroupService(client);

            // Act
            var response = await classUnderTest.DescribeSecurityGroupsAsync();

            // Assert
            Assert.IsTrue(response.SecurityGroups.Count >= 1);
        }
    }
}