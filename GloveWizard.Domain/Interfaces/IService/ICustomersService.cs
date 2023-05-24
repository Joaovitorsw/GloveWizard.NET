using GloveWizard.Domain.Helpers;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Utils.ResponseViewModel;

namespace GloveWizard.Domain.Interfaces.IService
{
    public interface ICustomersService
    {
        Task<ApiResponse<PaginationResponse<IEnumerable<Customer>>>> GetCustomersAsync(PaginationFilter filter);

        Task<ApiResponse<Customer?>> GetByCustomerIdAsync(int id);
        Task<ApiResponse<Customer>> InsertAsync(CustomerRequest customer);
        Task<ApiResponse<Customer>> UpdateAsync(Customer customer);
        Task<ApiResponse<Customer>> RemoveAsync(int id);
        Task<int> CompletedAsync();
    }
}
