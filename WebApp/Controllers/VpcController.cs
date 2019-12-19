using Business.AmazonWebServices.Ec2.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.Domain.Mappers.Interface;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class VpcController : Controller
    {
        private readonly IVpcService _vpcService;
        private readonly ISubnetService _subnetService;
        private readonly IRouteTableService _routeTableService;

        private readonly IDescribeVpcMapper _describeVpcMapper;
        private readonly IDescribeSubnetMapper _describeSubnetMapper;
        private readonly IDescribeRouteTableMapper _describeRouteTableMapper;

        public VpcController(IVpcService vpcService, ISubnetService subnetService, IRouteTableService routeTableService,
            IDescribeVpcMapper describeVpcMapper, IDescribeSubnetMapper describeSubnetMapper, IDescribeRouteTableMapper describeRouteTableMapper)
        {
            _vpcService = vpcService;
            _subnetService = subnetService;
            _routeTableService = routeTableService;

            _describeVpcMapper = describeVpcMapper;
            _describeSubnetMapper = describeSubnetMapper;
            _describeRouteTableMapper = describeRouteTableMapper;
        }

        public async Task<IActionResult> Describe()
        {
            var describeVpcsResponse = await _vpcService.DescribeVpcsAsync();
            var describeSubnetsResponse = await _subnetService.DescribeSubnetsAsync();
            var describeRouteTablesResponse = await _routeTableService.DescribeRouteTablesAsync();

            var viewModel = _describeVpcMapper.MapForDescribe(describeVpcsResponse);
            viewModel.Subnets = _describeSubnetMapper.MapForDescribe(describeSubnetsResponse);
            viewModel.RouteTables = _describeRouteTableMapper.MapForDescribe(describeRouteTablesResponse);

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