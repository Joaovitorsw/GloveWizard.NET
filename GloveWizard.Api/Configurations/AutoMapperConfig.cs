

using AutoMapper;
using GloveWizard.Domain.Models;
using GloveWizard.Infrastructure.Entities;

namespace GloveWizard.Configurations
{
    public static class AutoMapper
    {
        public static IServiceCollection CreateMapper(this IServiceCollection services)
        {


            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Customers, Custumer>().ForMember(o => o.CustomerID, b => b.MapFrom(z => z.customer_id)).ForMember(o => o.CustomerName, b => b.MapFrom(z => z.customer_name));
                cfg.CreateMap<Custumer, Customers>().ForMember(o => o.customer_id, b => b.MapFrom(z => z.CustomerID)).ForMember(o => o.customer_name, b => b.MapFrom(z => z.CustomerName));
                cfg.CreateMap<CustumerRequest, Customers>().ForMember(o => o.customer_name, b => b.MapFrom(z => z.CustomerName));
                
            }, AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }

    }
