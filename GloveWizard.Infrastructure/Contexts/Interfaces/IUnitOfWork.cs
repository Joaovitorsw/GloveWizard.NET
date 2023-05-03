
using GloveWizard.Infrastructure.Repositorys;

namespace GloveWizard.Data.Contexts.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CustomersRepository Custumers { get; }
        ContactsRepository Contacts { get; }
        Task<int> CompletedAsync();
    }
}


