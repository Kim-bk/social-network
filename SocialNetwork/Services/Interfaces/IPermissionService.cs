using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Models.DTOs.Responses.Base;

namespace SocialNetwork.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<string> GetCredentials(int userId);
        Task<GeneralResponse> AddCredential(CredentialRequest req);
        Task<GeneralResponse> RemoveCredential(CredentialRequest req);
    }
}
