


using GloveWizard.Data.Contexts;
using GloveWizard.Infrastructure.Entities;
using GloveWizard.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace GloveWizard.Infrastructure.Repositorys
{


    public class ContactsRepository : GenericRepository<Contacts>, IContactsRepository
    {
        public ContactsRepository(DataContext context, ILogger logger) : base(context, logger)
        {
        }
    }





}


