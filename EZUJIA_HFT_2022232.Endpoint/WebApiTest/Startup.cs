using EZUJIA_HFT_2022232.Logic;
using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Endpoint.WebApiTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MyDbContext>();

            services.AddTransient<IRepository<Cars>, CarsRepository>();
            services.AddTransient<IRepository<CarBrand>, CarBrandRepository>();
            services.AddTransient<IRepository<Rent>, RentsRepository>();


            services.AddTransient<ICarLogic, CarsLogic>();
            services.AddTransient<ICarBrandLogic, CarBrandLogic>();
            services.AddTransient<IRentLogic, RentLogic>();
            services.AddControllers();
            //services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "EZUJIA_HFT_2022232.Endpoint", Version = "v1" }); });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EZUJIA_HFT_2022232.Endpoint v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
