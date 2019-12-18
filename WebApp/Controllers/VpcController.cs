using Business.AmazonWebServices.Ec2.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class VpcController : Controller
    {
        private readonly IVpcService _vpcService;
        private readonly ISubnetService _subnetService;

        public VpcController(IVpcService vpcService, ISubnetService subnetService)
        {
            _vpcService = vpcService;
            _subnetService = subnetService;
        }

        public async Task<IActionResult> Describe()
        {
            var viewModel = new DescribeVpcModel();
            var describeVpcsResponse = await _vpcService.DescribeVpcsAsync();
            var firstVpc = describeVpcsResponse.Vpcs.Count > 0 
                ? describeVpcsResponse.Vpcs.Where(vpc => vpc.IsDefault).First() 
                : new Amazon.EC2.Model.Vpc();

            var describeSubnetsResponse = await _subnetService.DescribeSubnetsAsync();
            foreach (var subnet in describeSubnetsResponse.Subnets)
            {
                viewModel.Subnets.Add(new SubnetModel() 
                { 
                    SubnetId = subnet.SubnetId
                });
            }

            viewModel.VpcId = firstVpc.VpcId;
            return View(viewModel);
        }

        // GET: Vpc/CreateDefault
        public ActionResult CreateDefault()
        {
            var viewModel = new CreateDefaultVpcModel();
            return View(viewModel);
        }

        // POST: Vpc/CreateDefault
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDefault(IFormCollection collection)
        {
            try
            {
                var createDefaultVpcResponse = await _vpcService.CreateDefaultVpcAsync();
                var viewModel = new CreateDefaultVpcModel
                {
                    AlertPrimary = $"Default VPC created. VpcId={createDefaultVpcResponse.Vpc.VpcId}"
                };

                return View();
            }
            catch(Exception ex)
            {
                var viewModel = new CreateDefaultVpcModel
                {
                    AlertPrimary = ex.Message
                };
                return View(viewModel);
            }
        }
    }
}