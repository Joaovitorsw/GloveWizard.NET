


using GloveWizard.Data.Contexts;
using GloveWizard.Infrastructure.Entities;
using GloveWizard.Infrastructure.Interfaces.IGenericRepository;
using GloveWizard.Infrastructure.Interfaces.IRepository;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace GloveWizard.Infrastructure.Repositorys.CustomersRepository
{


    public class CustomersRepository : GenericRepository<Customers>, ICustomersRepository
    {
        public CustomersRepository(DataContext context, ILogger logger) : base(context, logger)
        {
        }
    }





}


