using Amazon.EC2;
using Amazon.ECR;
using Amazon.ECS;
using AwsAdmin.Application.Ec2;
using AwsAdmin.Application.Ec2.Interface;
using AwsAdmin.Web.Services;
using AwsAdmin.Web.Services.Interface;
using AwsAdmin.WebApp.Mappers;
using AwsAdmin.WebApp.Mappers.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AwsAdmin.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // appsettings.json
            var awsAccessKeyId = Configuration.GetSection("AwsAccessKeyId").Value;
            var awsSecretAccessKey = Configuration.GetSection("AwsSecretAccessKey").Value;
            var keyService = new KeyService(awsAccessKeyId, awsSecretAccessKey);

            // Amazon clients
            // `keyService` can be used to pass `AwsAccessKeyId` and `AwsSecretAccessKey`
            var cloudComputeClient = new AmazonEC2Client();
            var containerServiceClient = new AmazonECSClient();
            var containerRegistryClient = new AmazonECRClient();

            services.AddSingleton<IKeyService>(keyService);
            services.AddSingleton<IAmazonEC2>(cloudComputeClient);
            services.AddSingleton<IAmazonECS>(containerServiceClient);
            services.AddSingleton<IAmazonECR>(containerRegistryClient);

            // AwsAdmin.Application Services
            var vpcService = new VpcService(cloudComputeClient);
            var subnetService = new SubnetService(cloudComputeClient);
            var routeTableService = new RouteTableService(cloudComputeClient);
            var internetGatewayService = new InternetGatewayService(cloudComputeClient);
            var dhcpOptionsSetService = new DhcpOptionsSetService(cloudComputeClient);
            var networkAclsService = new NetworkAclsService(cloudComputeClient);
            var securityGroupService = new SecurityGroupService(cloudComputeClient);

            services.AddSingleton<IVpcService>(vpcService);
            services.AddSingleton<ISubnetService>(subnetService);
            services.AddSingleton<IRouteTableService>(routeTableService);
            services.AddSingleton<IInternetGatewayService>(internetGatewayService);
            services.AddSingleton<IDhcpOptionsSetService>(dhcpOptionsSetService);
            services.AddSingleton<INetworkAclsService>(networkAclsService);
            services.AddSingleton<ISecurityGroupService>(securityGroupService);

            // Mappers
            services.AddSingleton<IDescribeVpcMapper, DescribeVpcMapper>();
            services.AddSingleton<IDescribeSubnetMapper, DescribeSubnetMapper>();
            services.AddSingleton<IDescribeRouteTableMapper, DescribeRouteTableMapper>();
            services.AddSingleton<IDhcpOptionsSetsMapper, DhcpOptionsSetsMapper>();
            services.AddSingleton<IInternetGatewayMapper, InternetGatewayMapper>();
            services.AddSingleton<INetworkAclsMapper, NetworkAclsMapper>();
            services.AddSingleton<ISecurityGroupMapper, SecurityGroupMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
