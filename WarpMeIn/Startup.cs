using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WarpMeIn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WarpMeIn
{
    public class Startup
    {
        private IHostingEnvironment env;
        private IConfigurationRoot config;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            this.env = hostingEnvironment;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables();

            config = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WarpMeInDBContext>(options => options.UseSqlServer(config["ConnectionStrings:DefaultConnection"]));
            services.AddMvc();

            var serviceProvider = services.BuildServiceProvider();

            var dbContext = serviceProvider.GetService<WarpMeInDBContext>();

            DBInitializer.Initialize(dbContext);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" });
                config.MapRoute(
                    name: "Redirect",
                    template: "{controller=R}/{id}");
            });
        }
    }
}
