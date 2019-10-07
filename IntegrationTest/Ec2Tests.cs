using Business.AmazonWebServices;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class Ec2Tests
    {
        [SetUp]
        public void Setup()
        {
            //~ environment variables
            //AWS_ACCESS_KEY_ID
            //AWS_SECRET_ACCESS_KEY
        }

        [Test]
        public async Task CreateVPCEndpointAsync_should_create_vpc()
        {
            var classUnderTest = new Ec2();
            var response = await classUnderTest.CreateVPCEndpointAsync();

            Assert.Pass();
        }
    }
}