using GloveWizard.Domain.Models;
using GloveWizard.Domain.Utils.ResponseViewModel;

namespace GloveWizard.Domain.Interfaces.IService
{
    public interface ICustomersService
    {
        Task<ApiResponse<IList<Customer>>> GetCustomersAsync();

        Task<ApiResponse<Customer?>> GetByCustomerIdAsync(int id);
        Task<ApiResponse<Customer>> InsertAsync(CustomerRequest customer);
        Task<ApiResponse<Customer>> UpdateAsync(Customer customer);
        Task<ApiResponse<Customer>> RemoveAsync(int id);
        Task<int> CompletedAsync();
    }
}
