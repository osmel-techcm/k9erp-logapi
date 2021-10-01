using logCore.Interfaces;
using logShared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace logShared
{
    public static class Startup
    {
        public static IServiceCollection AddDependenciesShared(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ILogChangeExtendedService, LogChangeExtendedService>();
            //services.AddTransient<ITerminalControllerService, TerminalControllerService>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
