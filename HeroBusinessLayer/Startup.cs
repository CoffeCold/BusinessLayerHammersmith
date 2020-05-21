using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HeroBusinessLayer.Services;
using HeroBusinessLayer.Models;
using HeroBusinessLayer.Helpers;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HeroBusinessLayer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //readonly string AllThinkableOrigins = "_myAllThinkableOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            // Appsettings in appsettings.json used for DI services
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddScoped<IHeroesService, HeroesService>();

            services.AddControllers();

            // use configured connectionstring directly
            services.AddDbContext<AngularHeroesContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AngularHeroesDbConstr")));


        }

        // this method allows a injected logger and is called, we use logging to check the configuration 
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("Configure called");


            logger.LogInformation("AnyConfig string {0}", Configuration.GetValue<String>("AnyConfig"));

            logger.LogInformation("Connection string {0}", Configuration.GetConnectionString("AngularHeroesDbConstr"));


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
