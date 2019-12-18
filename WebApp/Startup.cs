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
using WebApp.Common;
using WebApp.Common.Interface;

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
            // KeyService can be used to pass `AwsAccessKeyId` and `AwsSecretAccessKey`
            var cloudComputeClient = new AmazonEC2Client();

            // Services
            var vpcService = new VpcService(cloudComputeClient);
            var subnetService = new SubnetService(cloudComputeClient);

            // All the DI's <3
            services.AddSingleton<IKeyService>(keyService);
            services.AddSingleton<IAmazonEC2>(cloudComputeClient);
            services.AddSingleton<IAmazonECS, AmazonECSClient>();  
            services.AddSingleton<IAmazonECR, AmazonECRClient>();
            services.AddSingleton<IVpcService>(vpcService);
            services.AddSingleton<ISubnetService>(subnetService);
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
