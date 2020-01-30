using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using pf_maestros.Data.Repositories;
using pf_maestros.Data.Repositories.Impl;
using pf_maestros.Models;
using pf_maestros.Services;
using pf_maestros.Services.Interfaces;

namespace pf_maestros
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
            services.AddScoped<IMaestrosServices, MaestrosServices>();
            services.AddScoped<IMaestrosRepository, MaestrosRepository>();
            services.AddScoped<IProductosRepositories, ProductosRepositories>();
            services.AddScoped<IProductosServices, ProductosServices>();
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
