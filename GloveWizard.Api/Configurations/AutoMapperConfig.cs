

using AutoMapper;
using GloveWizard.Domain.Models;
using GloveWizard.Infrastructure.Entities;

namespace GloveWizard.Configurations
{
    public static class AutoMapper
    {
        public static IServiceCollection CreateMapper(this IServiceCollection services)
        {


            services.AddAutoMapper(IMapperConfigurationExpression =>
            {
                IMapperConfigurationExpression.CreateMap<Customers, Costumer>().ForMember(
                    costumer => costumer.CustomerID, option => option.MapFrom(customers => customers.customer_id)
                    ).ForMember(
                    costumer => costumer.CustomerName, option => option.MapFrom(customers => customers.customer_name)
                    ).ForMember(
                    costumer => costumer.Contact, option => option.MapFrom(customers => customers.contacts)
                    )
                    .ReverseMap();

                IMapperConfigurationExpression.CreateMap<Contacts, Contact>().ForMember(
                    contact => contact.CustomerID, option => option.MapFrom(contacts => contacts.customer_id)
                    ).ForMember(
                    contact => contact.Email, option => option.MapFrom(contacts => contacts.email)
                    ).ForMember(
                    contact => contact.Phone, option => option.MapFrom(contacts => contacts.phone)
                    ).ForMember(
                    contact => contact.ContactName, option => option.MapFrom(contacts => contacts.contact_name)
                    ).ForMember(
                    contact => contact.ContactID, option => option.MapFrom(contacts => contacts.contact_id)
                    )
                    .ReverseMap();

                IMapperConfigurationExpression.CreateMap<CostumerRequest, Customers>().ForMember(
                    customers => customers.customer_name, option => option.MapFrom(costumer => costumer.CustomerName)
                    ).ForMember(
                    costumer => costumer.contacts, option => option.MapFrom(customers => customers.Contact)
                    ).ReverseMap(); ;

            }, AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }

}
