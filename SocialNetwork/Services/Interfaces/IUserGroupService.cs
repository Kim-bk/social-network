using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Models.DTOs.Responses;
using SocialNetwork.Models.DTOs.Responses.Base;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IUserGroupService
    {
        Task<UserGroupResponse> GetUserGroups();
        Task<GeneralResponse> AddUserGroup(string userGroupName);
        Task<GeneralResponse> DeleteUserGroup(int userGroupId);
        Task<GeneralResponse> UpdateUserGroup(UserGroupRequest req);
    }
}
