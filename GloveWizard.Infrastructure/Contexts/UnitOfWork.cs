using GloveWizard.Data.Contexts.Interfaces;
using GloveWizard.Infrastructure.Repositores;
using Microsoft.Extensions.Logging;

namespace GloveWizard.Data.Contexts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;
        public CustomersRepository Customers { get; private set; }
        public ContactsRepository Contacts { get; private set; }
        public UnitOfWork(
        DataContext context,
        ILoggerFactory logger
        )
        {
            _context = context;
            _logger = logger.CreateLogger("logs");
            Customers = new CustomersRepository(_context, _logger);
            Contacts = new ContactsRepository(_context, _logger);
        }

        public async Task<int> CompletedAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
