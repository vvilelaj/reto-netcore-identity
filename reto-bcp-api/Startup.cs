using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using reto_bcp_api.Persistance;
using Microsoft.EntityFrameworkCore;
using reto_bcp_api.Persistance.Repositories.Interfaces;
using reto_bcp_api.Persistance.Repositories;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using reto_bcp_api.Services.Interfaces;
using reto_bcp_api.Services;

namespace reto_bcp_api
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
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                    opts.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services
                .AddDbContext<RetoBCPDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("RetoBCPDbContext"));
                });

            services
                .AddScoped<IAgenciaRepository, AgenciaRepository>();
            services
                .AddScoped<IAgenciaService, AgenciaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
