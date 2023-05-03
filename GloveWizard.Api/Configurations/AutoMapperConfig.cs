

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
                IMapperConfigurationExpression.CreateMap<Customers, Custumer>().ForMember(
                    custumer => custumer.CustomerID, option => option.MapFrom(customers => customers.customer_id)
                    ).ForMember(
                    custumer => custumer.CustomerName, option => option.MapFrom(customers => customers.customer_name)
                    ).ForMember(
                    custumer => custumer.Contact, option => option.MapFrom(customers => customers.contacts)
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

                IMapperConfigurationExpression.CreateMap<CustumerRequest, Customers>().ForMember(
                    customers => customers.customer_name, option => option.MapFrom(custumer => custumer.CustomerName)
                    ).ForMember(
                    custumer => custumer.contacts, option => option.MapFrom(customers => customers.Contact)
                    ).ReverseMap(); ;

            }, AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }

}
