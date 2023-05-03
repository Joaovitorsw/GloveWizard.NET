

using GloveWizard.Data.Contexts;
using GloveWizard.Data.Contexts.Interfaces;
using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Domain.Service;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GloveWizard.Configurations
{
    public static class DependecyConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Work Interfaces
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<ICustomersService, CustomersService>();


            return services;
        }
    }
}
