using ContactApp.API.Data;
using ContactApp.API.Helpers;
using ContactApp.API.Helpers.CustomExtensions;
using ContactApp.API.Model;
using FluentValidation.AspNetCore;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API
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
            services.MyCustomLifeCycles();
            services.AddDbContext<ContactDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("ContactApp.API");
                });
            });
            services.Configure<CustomConnectionStringOptions>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<ContactCacheKeys>(Configuration.GetSection("ContactCacheKeys"));
            services.Configure<ContactCacheStringHelpers>(Configuration.GetSection("ContactCacheStringHelpers"));
            services.Configure<ContactInfoCacheKeys>(Configuration.GetSection("ContactInfoCacheKeys"));
            services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Startup>(null, ServiceLifetime.Singleton);
            });
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("domain"));
            //});
            services.AddCors(options => { options.AddPolicy("AllowOrigin", policy => policy.AllowAnyOrigin()); });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContactApp.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContactApp.API v1"));
            }
            else
            {
                app.UseCustomException();
            }

            //app.UseCors(builder => builder.WithOrigins("domain").AllowAnyHeader());

            app.UseCors
            (
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
