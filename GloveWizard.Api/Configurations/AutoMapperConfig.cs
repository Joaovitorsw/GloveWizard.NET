using AutoMapper;
using GloveWizard.Domain.Models;
using GloveWizard.Infrastructure.Entities;

namespace GloveWizard.Configurations
{
    public static class AutoMapper
    {
        public static IServiceCollection CreateMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                IMapperConfigurationExpression =>
                {
                    IMapperConfigurationExpression
                        .CreateMap<Customers, Customer>()
                        .ForMember(
                            customer => customer.CustomerID,
                            option => option.MapFrom(customers => customers.CustomerID)
                        )
                        .ForMember(
                            customer => customer.CustomerName,
                            option => option.MapFrom(customers => customers.CustomerName)
                        )
                        .ForMember(
                            customer => customer.Contacts,
                            option => option.MapFrom(customers => customers.Contacts)
                        )
                        .ReverseMap().PreserveReferences();

                    IMapperConfigurationExpression
                        .CreateMap<Contacts, Contact>()
                        .ForMember(
                            contact => contact.CustomerID,
                            option => option.MapFrom(contacts => contacts.CustomerID)
                        )
                        .ForMember(
                            contact => contact.Email,
                            option => option.MapFrom(contacts => contacts.Email)
                        )
                        .ForMember(
                            contact => contact.Phone,
                            option => option.MapFrom(contacts => contacts.Phone)
                        )
                        .ForMember(
                            contact => contact.ContactName,
                            option => option.MapFrom(contacts => contacts.ContactName)
                        )
                        .ForMember(
                            contact => contact.ContactID,
                            option => option.MapFrom(contacts => contacts.ContactID)
                        )
                        .ReverseMap().PreserveReferences();

                    IMapperConfigurationExpression
                        .CreateMap<CustomerRequest, Customers>()
                        .ForMember(
                            customers => customers.CustomerName,
                            option => option.MapFrom(customer => customer.CustomerName)
                        )
                        .ForMember(
                            customer => customer.Contacts,
                            option => option.MapFrom(customers => customers.Contacts)
                        )
                        .ReverseMap().PreserveReferences();
                    ;
                },
                AppDomain.CurrentDomain.GetAssemblies()
            );

            return services;
        }
    }
}
