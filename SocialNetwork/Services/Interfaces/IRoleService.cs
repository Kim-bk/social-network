using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Models.DTOs.Responses.Base;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IRoleService
    {
        Task<GeneralResponse> CreateRole(string roleName);
        Task<GeneralResponse> UpdateRole(RoleRequest req);
        Task<GeneralResponse> DeleteRole(int roleId);
    }
}
