using Amazon.EC2;
using Amazon.ECR;
using Amazon.ECS;
using AwsAdmin.Web.Models;
using AwsAdmin.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AwsAdmin.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAmazonECS _amazonECSClient;
        private readonly IAmazonEC2 _cloudComputeClient;
        private readonly IAmazonECR _amazonECRClient;

        public HomeController(ILogger<HomeController> logger, IAmazonECS amazonECSClient, 
            IAmazonEC2 cloudComputeClient, IAmazonECR amazonECRClient)
        {
            _amazonECSClient = amazonECSClient;
            _cloudComputeClient = cloudComputeClient;
            _amazonECRClient = amazonECRClient;
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
