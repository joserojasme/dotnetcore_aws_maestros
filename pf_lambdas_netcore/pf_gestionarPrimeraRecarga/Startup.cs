using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pf_gestionarPrimeraRecarga.Data.Repositories;
using pf_gestionarPrimeraRecarga.Data.Repositories.Impl;
using pf_gestionarPrimeraRecarga.Models;
using pf_gestionarPrimeraRecarga.Services;
using pf_gestionarPrimeraRecarga.Services.Interfaces;

namespace pf_gestionarPrimeraRecarga
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options =>
            options.UseMySQL(Configuration.GetConnectionString("dbPro")));

            services.AddScoped<Context, Context>();
            services.AddScoped<IAgregarPrimeraRecargaServices, AgregarPrimeraRecargaServices>();
            services.AddScoped<IAgregarPrimeraRecargaRepository, AgregarPrimeraRecargaRepository>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.Use((context, next) =>
            {
                context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                return next.Invoke();
            });

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors(options => options.AllowAnyOrigin());
        }
    }
}
