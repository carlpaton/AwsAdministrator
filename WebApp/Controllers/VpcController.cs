using Amazon.EC2;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class VpcController : Controller
    {
        private readonly IAmazonEC2 _cloudComputeClient;

        public VpcController(IAmazonEC2 cloudComputeClient)
        {
            _cloudComputeClient = cloudComputeClient;
        }

        public async Task<IActionResult> Describe()
        {
            var viewModel = new DescribeVpcModel();
            var describeVpcsResponse = await _cloudComputeClient.DescribeVpcsAsync();
            var firstVpc = describeVpcsResponse.Vpcs.Count > 0 
                ? describeVpcsResponse.Vpcs.Where(vpc => vpc.IsDefault).First() 
                : new Amazon.EC2.Model.Vpc();
            
            viewModel.VpcId = firstVpc.VpcId;
            return View(viewModel);
        }
    }
}