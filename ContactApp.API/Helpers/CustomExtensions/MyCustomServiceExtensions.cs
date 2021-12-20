using ContactApp.API.Data.Repositories;
using ContactApp.API.Interfaces;
using ContactApp.API.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Helpers.CustomExtensions
{
    public static class MyCustomServiceExtensions
    {
        public static IServiceCollection MyCustomLifeCycles(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
            services.AddScoped<IContactService, ContactService>();
            services.AddSingleton<IRedisService, RedisService>();
            return services;
        }
    }
}
