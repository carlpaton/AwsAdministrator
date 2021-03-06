﻿using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using System.Threading.Tasks;

namespace AwsAdmin.Application.Autoscaling
{
    /* TODO - LaunchConfigurationService interface and mapper
     * 
     * LaunchConfigurationService needs an interface
     * CreateLaunchConfigurationRequest needs a mapper
     * 
     */


    public class LaunchConfigurationService
    {
        private readonly IAmazonAutoScaling _autoScalingClient;

        public LaunchConfigurationService(IAmazonAutoScaling autoScalingClient) 
        {
            _autoScalingClient = autoScalingClient;
        }

        public async Task<CreateLaunchConfigurationResponse> CreateLaunchConfigurationAsync(CreateLaunchConfigurationRequest request) 
        {
            var response = await _autoScalingClient.CreateLaunchConfigurationAsync(request);
            return response;
        }
    }
}
