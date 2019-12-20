using Amazon.EC2;
using Amazon.ECR;
using Amazon.ECS;
using Business.AmazonWebServices.Ec2;
using Business.AmazonWebServices.Ec2.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Domain.Mappers;
using WebApp.Domain.Mappers.Interface;
using WebApp.Domain.Services;
using WebApp.Domain.Services.Interface;

namespace WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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

            // Services
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
