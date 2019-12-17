using Amazon.EC2;
using Amazon.ECR;
using Amazon.ECS;
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

            // All the DI's <3
            services.AddSingleton<IKeyService>(keyService);          
            services.AddSingleton<IAmazonECS, AmazonECSClient>(); // KeyService can be used to pass `AwsAccessKeyId` and `AwsSecretAccessKey` 
            services.AddSingleton<IAmazonEC2, AmazonEC2Client>();
            services.AddSingleton<IAmazonECR, AmazonECRClient>();
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
