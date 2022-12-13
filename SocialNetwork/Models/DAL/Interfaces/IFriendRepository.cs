using SocialNetwork.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Models.DAL.Interfaces
{
    public interface IFriendRepository : IRepository<Friend>
    {
        public Task<List<int>> GetFriendsOfUser(int userId);
        public Task<bool> CheckFriend(int userId, int friendId);
        public Task<List<int>> GetInvitationFriendsOfUser(int userId);
    }
}
