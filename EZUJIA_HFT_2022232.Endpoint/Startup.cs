using EZUJIA_HFT_2022232.Logic;
using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Endpoint
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MyDbContext>();

            services.AddTransient<IRepository<Cars>, CarsRepository>();
            services.AddTransient<IRepository<CarBrand>, CarBrandRepository>();
            services.AddTransient<IRepository<Rent>, RentsRepository>();


            services.AddTransient<ICarLogic, CarsLogic>();
            services.AddTransient<ICarBrandLogic, CarBrandLogic>();
            services.AddTransient<IRentLogic, RentLogic>();


        }
    }
}
