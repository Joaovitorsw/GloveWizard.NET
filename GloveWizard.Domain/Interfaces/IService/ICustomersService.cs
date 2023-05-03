using GloveWizard.Domain.Models;
using GloveWizard.Domain.Service;
using GloveWizard.Domain.Utils.ResponseViewModel;
using GloveWizard.Infrastructure.Entities;

namespace GloveWizard.Domain.Interfaces.IService
{

    public interface ICustomersService
    {
        Task<ApiResponse<IList<Custumer>>> GetCustomersAsync();

        Task<ApiResponse<Custumer>> GetByCustomerIdAsync(int id);
        Task<ApiResponse<Custumer>> InsertAsync(CustumerRequest custumer);
        Task<ApiResponse<Custumer>> UpdateAsync(Custumer custumer);
        Task<ApiResponse<Custumer>> RemoveAsync(int id);
        Task<int> CompletedAsync();

    }
    
}

