using GloveWizard.Domain.Helpers;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Utils.ResponseViewModel;
using GloveWizard.Infrastructure.Entities;
using System.Threading.Tasks;

namespace GloveWizard.Domain.Interfaces.IService
{
    public interface IAuthService
    {
        public Task<ApiResponse<LoginResponse?>> Login(LoginRequest user);
        public Task<ApiResponse<PaginationResponse<IEnumerable<Users>>>> GetUsersAsync(
            PaginationFilter filter
        );
        public Task<Users> GetUserByNickName(string Login);
        string GetJwtToken(Users user);
    }
}
