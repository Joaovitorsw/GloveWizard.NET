
using GloveWizard.Infrastructure.Interfaces.IRepository;
using GloveWizard.Infrastructure.Repositorys.CustomersRepository;

namespace GloveWizard.Data.Contexts.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CustomersRepository Custumers { get; }
        Task<int> CompletedAsync();
    }
}


