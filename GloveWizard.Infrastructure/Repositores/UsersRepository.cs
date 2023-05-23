using GloveWizard.Data.Contexts;
using GloveWizard.Infrastructure.Entities;
using GloveWizard.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace GloveWizard.Infrastructure.Repositores
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        public UsersRepository(DataContext context, ILogger logger)
            : base(context, logger) { }
    }
}
