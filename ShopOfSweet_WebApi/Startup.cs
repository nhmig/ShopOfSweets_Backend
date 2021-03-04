using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopOfSweet_WebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace ShopOfSweet_WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //change password
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SweetsDbContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("ShopOfSweetsConnection")));
            services.AddScoped<IProductRepository, SqlProductRepository>();
            services.AddScoped<IDealRepository, SqlDealRepository>();

            //services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Place Info Service API",
                    Version = "v2",
                    Description = "Sample service for Learner",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

           // app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My First Swagger");
            });

        }
    }
}
