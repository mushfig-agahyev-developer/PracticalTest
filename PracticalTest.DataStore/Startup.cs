using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using PracticalTest.DataStore.DAL;
using PracticalTest.DataStore.Interfaces;
using PracticalTest.DataStore.Repositories;
using PracticalTest.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore
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
            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddDbContext<AppStore>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]);
            });

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            var requirements = new List<IBaseLoanRequirement>()
            {
                new LoanAmontRequirement(),
                new LoanSalaryCompare(),
            };

            services.AddScoped<List<IBaseLoanRequirement>>(provider => requirements);

            /*
            services.AddCors(o => o.AddPolicy("PracticalTest", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            */
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseCors("PracticalTest");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
