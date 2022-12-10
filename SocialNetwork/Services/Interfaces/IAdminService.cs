using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Models.DTOs.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<CredentialResponse>> GetRolesOfUserGroup(int userGroup);
        Task<UserResponse> Login(LoginRequest request);
    }
}
