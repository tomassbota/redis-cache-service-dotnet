using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using RedisCacheExtension.Interfaces;
using RedisCacheExtension.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCacheExtension
{
    public static class RedisCacheServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, Action<RedisCacheOptions> configureOptions)
        {
            services.AddStackExchangeRedisCache(configureOptions);

            services.AddScoped<IRedisCacheService, RedisCacheService>();

            return services;
        }
    }
}
