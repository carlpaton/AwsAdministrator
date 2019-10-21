using Business.AmazonWebServices.Ec2;
using Business.AmazonWebServices.Ec2.Interface;
using IntegrationTest.Plumbing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTest.Ec2
{
    public class RouteTableServiceTests
    {
        [SetUp]
        public void Setup()
        {
            new EnvironmentVariables();
        }

        [Test]
        public async Task DescribeRouteTablesAsync_when_any_exist_should_describe_route_tables()
        {
            // Arrange
            var client = new EnvironmentVariables().CloudComputeClient();
            IRouteTableService classUnderTest = new RouteTableService(client);

            // Act
            var response = await classUnderTest.DescribeRouteTablesAsync();

            // Assert
            Assert.IsTrue(response.RouteTables != null);
            Assert.IsTrue(response.RouteTables.Count >= 1);
        }
    }
}
