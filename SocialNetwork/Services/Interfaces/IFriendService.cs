using SocialNetwork.Models.DTOs;
using SocialNetwork.Models.DTOs.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IFriendService
    {
        public Task<List<UserDTO>> GetFriends(int userDTO);
        public Task<List<UserDTO>> GetInvatitationFriends(int userDTO);
        public Task<bool> ManageFriend(int userId, FriendRequest req);
        public Task<List<UserDTO>> SearchFriend(int userId, string userName);
        public Task<bool> AddFriend(int userId, int friendId);
    }
}
