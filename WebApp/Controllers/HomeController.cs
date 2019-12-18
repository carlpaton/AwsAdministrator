using System.Diagnostics;
using Amazon.EC2;
using Amazon.ECR;
using Amazon.ECS;
using Microsoft.AspNetCore.Mvc;
using WebApp.Domain.Services.Interface;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAmazonECS _amazonECSClient;
        private readonly IAmazonEC2 _cloudComputeClient;
        private readonly IAmazonECR _amazonECRClient;
        private readonly IKeyService _keyService;

        public HomeController(IAmazonECS amazonECSClient, IAmazonEC2 cloudComputeClient, IAmazonECR amazonECRClient, IKeyService keyService) 
        {
            _amazonECSClient = amazonECSClient;
            _cloudComputeClient = cloudComputeClient;
            _amazonECRClient = amazonECRClient;
            _keyService = keyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Client()
        {
            var viewModel = new ClientModel
            {
                AwsAccessKeyId = _keyService.GetAwsAccessKeyId(),
                AwsSecretAccessKey = _keyService.GetAwsSecretAccessKey(),
                AmazonECSClientModel = new AmazonECSClientModel() 
                {
                    AuthenticationServiceName = _amazonECSClient.Config.AuthenticationServiceName,
                    RegionEndpointSystemName = _amazonECSClient.Config.RegionEndpoint.SystemName
                },
                AmazonEC2ClientModel = new AmazonEC2ClientModel()
                {
                    AuthenticationServiceName = _cloudComputeClient.Config.AuthenticationServiceName,
                    RegionEndpointSystemName = _cloudComputeClient.Config.RegionEndpoint.SystemName
                },
                AmazonECRClientModel = new AmazonECRClientModel()
                {
                    AuthenticationServiceName = _amazonECRClient.Config.AuthenticationServiceName,
                    RegionEndpointSystemName = _amazonECRClient.Config.RegionEndpoint.SystemName
                }
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
