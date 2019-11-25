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
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using System;
//using Microsoft.IdentityModel;
using reto_bcp_api.Persistance.Models;
using Microsoft.AspNetCore.Identity;

namespace reto_bcp_api
{

    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
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
                .AddIdentity<RetoBcpUser, IdentityRole>(opts =>
                {
                    opts.Password = new PasswordOptions();
                    opts.Password.RequiredLength = 4;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                    opts.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<RetoBCPDbContext>();

            services
                .AddScoped<IAgenciaRepository, AgenciaRepository>();
            services
                .AddScoped<IAgenciaService, AgenciaService>();
            services
                .AddScoped<ICuentasUsuarioService, CuentasUsuarioService>();

            services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfiguration.ContactName, Url = SwaggerConfiguration.ContactUrl };
                swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
                                   new Info
                                   {
                                       Title = SwaggerConfiguration.DocInfoTitle,
                                       Version = SwaggerConfiguration.DocInfoVersion,
                                       Description = SwaggerConfiguration.DocInfoDescription,
                                       Contact = contact
                                   }
                                    );

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swagger.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentity();

            app.UseMvc();
        }
    }
}
