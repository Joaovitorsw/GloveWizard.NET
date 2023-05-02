using GloveWizard.Domain.Models;
using GloveWizard.Domain.Service;
using GloveWizard.Domain.Utils.ResponseViewModel;
using GloveWizard.Infrastructure.Entities;

namespace GloveWizard.Domain.Interfaces.IService
{

    public interface ICustomersService
    {
        Task<ResponseViewModel<List<Custumer>>> GetCustomers();

        Task<ResponseViewModel<Custumer>> GetByCustomerID(int id);
        Task<ResponseViewModel<Custumer>> InsertAsync(CustumerRequest custumer);
        ResponseViewModel<Custumer> Update(Custumer custumer);
        Task<int> CompletedAsync();

    }
    
}

