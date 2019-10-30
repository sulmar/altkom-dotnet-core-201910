using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Altkom.DotnetCore.Infrastructure;
using Altkom.DotnetCore.Infrastructure.Fakers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Altkom.DotnetCore.WebApi
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public Startup(IHostingEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
             
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddXmlFile("appsettings.xml", optional: true)
                ;

            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, FakeCustomerRepository>();
            services.AddScoped<CustomerFaker>();
            services.AddScoped<AddressFaker>();

            services.Configure<CustomerOptions>(Configuration.GetSection("CustomerOptions"));

            //var customerOptions = new CustomerOptions();
            //Configuration.GetSection("CustomerOptions").Bind(customerOptions);
            //services.AddSingleton(customerOptions);


            // dotnet add package Swashbuckle.AspNetCore

            services.AddSwaggerGen(options 
                => options.SwaggerDoc("v1", new Info { Title = "My Api", Version = "1.0" }));

            // dotnet add package Microsoft.AspNetCore.Mvc.Formatters.Xml
            
            services.AddMvc()
                .AddXmlSerializerFormatters()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            var customerCount = Configuration["CustomerCount"];

            var url = Configuration["SmsService:Url"];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options => 
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api"));

           // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
