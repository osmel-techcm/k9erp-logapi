﻿using logCore.Interfaces;
using logCore.Services;
using logInfrastructure.Data;
using logInfrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace reportInfrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ILogChangeService, LogChangeService>();
            services.AddTransient<ILogChangeRepo, LogChangeRepo>();

            return services;
        }

        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder applicationBuilder, MultitenantDbContext appDbContext, IHttpContextAccessor accessor, IConfiguration configuration)
        {
            applicationBuilder.Use(async (context, next) => {
                using (var tenantDbContext = new MultitenantDbContext(accessor, configuration))
                {
                    if (accessor.HttpContext.User.Identity.IsAuthenticated)
                    {
                        tenantDbContext.Database.Migrate();
                    }
                }
                await next();
            });

            return applicationBuilder;
        }
    }
}
