

using GloveWizard.Data.Contexts;
using GloveWizard.Data.Contexts.Interfaces;
using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Service;
using GloveWizard.Infrastructure.Interfaces.IRepository;
using GloveWizard.Infrastructure.Repositorys;
using GloveWizard.Infrastructure.Repositorys.CustomersRepository;
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

            // Services
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(CustomersService), typeof(CustomersService));


            return services;
        }
    }
}
