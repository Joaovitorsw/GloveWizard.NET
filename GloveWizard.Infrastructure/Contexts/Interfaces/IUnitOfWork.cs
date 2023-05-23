
using GloveWizard.Infrastructure.Repositores;

namespace GloveWizard.Data.Contexts.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CustomersRepository Customers { get; }
        ContactsRepository Contacts { get; }
        UsersRepository Users { get; }
        Task<int> CompletedAsync();
    }
}


