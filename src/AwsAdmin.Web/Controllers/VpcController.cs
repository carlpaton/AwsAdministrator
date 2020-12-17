using AwsAdmin.Application.Ec2.Interface;
using AwsAdmin.WebApp.Mappers.Interface;
using AwsAdmin.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AwsAdmin.Web.Controllers
{
    public class VpcController : Controller
    {
        private readonly IVpcService _vpcService;
        private readonly ISubnetService _subnetService;
        private readonly IRouteTableService _routeTableService;
        private readonly IInternetGatewayService _internetGatewayService;
        private readonly IDhcpOptionsSetService _dhcpOptionsSetService;
        private readonly INetworkAclsService _networkAclsService;
        private readonly ISecurityGroupService _securityGroupService;

        private readonly IDescribeVpcMapper _describeVpcMapper;
        private readonly IDescribeSubnetMapper _describeSubnetMapper;
        private readonly IDescribeRouteTableMapper _describeRouteTableMapper; 
        private readonly IInternetGatewayMapper _internetGatewayMapper;
        private readonly IDhcpOptionsSetsMapper _dhcpOptionsSetsMapper;
        private readonly INetworkAclsMapper _networkAclsMapper;
        private readonly ISecurityGroupMapper _securityGroupMapper;

        public VpcController(
            IVpcService vpcService, ISubnetService subnetService, IRouteTableService routeTableService, IInternetGatewayService internetGatewayService, 
            IDhcpOptionsSetService dhcpOptionsSetService, INetworkAclsService networkAclsService, ISecurityGroupService securityGroupService,
            IDescribeVpcMapper describeVpcMapper, IDescribeSubnetMapper describeSubnetMapper, IDescribeRouteTableMapper describeRouteTableMapper,
            IInternetGatewayMapper internetGatewayMapper, IDhcpOptionsSetsMapper dhcpOptionsSetsMapper, INetworkAclsMapper networkAclsMapper,
            ISecurityGroupMapper securityGroupMapper)
        {
            _vpcService = vpcService;
            _subnetService = subnetService;
            _routeTableService = routeTableService;
            _internetGatewayService = internetGatewayService;
            _dhcpOptionsSetService = dhcpOptionsSetService;
            _networkAclsService = networkAclsService;
            _securityGroupService = securityGroupService;

            _describeVpcMapper = describeVpcMapper;
            _describeSubnetMapper = describeSubnetMapper;
            _describeRouteTableMapper = describeRouteTableMapper;
            _internetGatewayMapper = internetGatewayMapper;
            _dhcpOptionsSetsMapper = dhcpOptionsSetsMapper;
            _networkAclsMapper = networkAclsMapper;
            _securityGroupMapper = securityGroupMapper;
        }

        public async Task<IActionResult> Describe()
        {
            var describeVpcsResponse = await _vpcService.DescribeVpcsAsync();
            var describeSubnetsResponse = await _subnetService.DescribeSubnetsAsync();
            var describeRouteTablesResponse = await _routeTableService.DescribeRouteTablesAsync();
            var describeInternetGatewaysResponse = await _internetGatewayService.DescribeInternetGatewaysAsync();
            var describeDhcpOptionsSetResponse = await _dhcpOptionsSetService.DescribeDhcpOptionsAsync();
            var describeNetworkAclsResponse = await _networkAclsService.DescribeNetworkAclsAsync();
            var describeSecurityGroupsResponse = await _securityGroupService.DescribeSecurityGroupsAsync();

            var viewModel = _describeVpcMapper.MapForDescribe(describeVpcsResponse);
            viewModel.Subnets = _describeSubnetMapper.MapForDescribe(describeSubnetsResponse);
            viewModel.RouteTables = _describeRouteTableMapper.MapForDescribe(describeRouteTablesResponse);
            viewModel.InternetGateways = _internetGatewayMapper.MapForDescribe(describeInternetGatewaysResponse);
            viewModel.DhcpOptionsSets = _dhcpOptionsSetsMapper.MapForDescribe(describeDhcpOptionsSetResponse);
            viewModel.NetworkAcls = _networkAclsMapper.MapForDescribe(describeNetworkAclsResponse);
            viewModel.SecurityGroups = _securityGroupMapper.MapForDescribe(describeSecurityGroupsResponse);

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