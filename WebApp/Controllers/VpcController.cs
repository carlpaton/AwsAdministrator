using Business.AmazonWebServices.Ec2.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Mappers.Interface;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class VpcController : Controller
    {
        private readonly IVpcService _vpcService;
        private readonly ISubnetService _subnetService;
        private readonly IDescribeVpcModelMapper _describeVpcModelMapper;

        public VpcController(IVpcService vpcService, ISubnetService subnetService, IDescribeVpcModelMapper describeVpcModelMapper)
        {
            _vpcService = vpcService;
            _subnetService = subnetService;
            _describeVpcModelMapper = describeVpcModelMapper;
        }

        public async Task<IActionResult> Describe()
        {
            var describeVpcsResponse = await _vpcService.DescribeVpcsAsync();
            var describeSubnetsResponse = await _subnetService.DescribeSubnetsAsync();
            var viewModel = _describeVpcModelMapper.MapForDescribe(describeVpcsResponse, describeSubnetsResponse);

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