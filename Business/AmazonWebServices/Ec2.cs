using Amazon.EC2;
using Amazon.EC2.Model;
using System.Threading.Tasks;

namespace Business.AmazonWebServices
{
    public class Ec2
    {
        public async Task<VpcEndpoint> CreateVPCEndpointAsync()
        {
            var client = new AmazonEC2Client();
            var vpcRequest = new CreateVpcRequest("10.0.0.0/16");
            var vpcResponse = await client.CreateVpcAsync(vpcRequest);
            var vpc = vpcResponse.Vpc;
            var endpointRequest = new CreateVpcEndpointRequest
            {
                VpcId = vpc.VpcId,
                //ServiceName = "com.amazonaws.ap-southeast-2.ec2"
            };
            var cVpcErsp = await client.CreateVpcEndpointAsync(endpointRequest);
            return cVpcErsp.VpcEndpoint;
        }

        public async Task<DescribeVpcEndpointServicesResponse> DescribeVpcEndpointServicesAsync()
        {
            var request = new DescribeVpcEndpointServicesRequest();
            var client = new AmazonEC2Client();
            return await client.DescribeVpcEndpointServicesAsync(request);
        }
    }
}
