using SocialNetwork.Models.DTOs;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Models.DTOs.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IAdminService
    {
        public Task<List<CredentialResponse>> GetRolesOfUserGroup(int userGroup);
        public Task<UserResponse> Login(LoginRequest request);
        public Task<bool> ApprovePost(int postId, string action);
        public Task<List<PostDTO>> GetUnapprovedPosts();
    }
}
