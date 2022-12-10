using SocialNetwork.Models;
using SocialNetwork.Models.DTOs.Responses;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<TokenResponse> Authenticate(User usser, string listCredentials);
    }
}
