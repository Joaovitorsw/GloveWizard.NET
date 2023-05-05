using GloveWizard.Domain.Models;
using GloveWizard.Domain.Service;
using GloveWizard.Domain.Utils.ResponseViewModel;
using GloveWizard.Infrastructure.Entities;

namespace GloveWizard.Domain.Interfaces.IService
{

    public interface ICustomersService
    {
        Task<ApiResponse<IList<Costumer>>> GetCustomersAsync();

        Task<ApiResponse<Costumer>> GetByCustomerIdAsync(int id);
        Task<ApiResponse<Costumer>> InsertAsync(CostumerRequest costumer);
        Task<ApiResponse<Costumer>> UpdateAsync(Costumer costumer);
        Task<ApiResponse<Costumer>> RemoveAsync(int id);
        Task<int> CompletedAsync();

    }

}

