using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Models.DAL.Interfaces
{
    public interface IFriendRepository
    {
        public Task<List<int>> GetFriendsOfUser(int userId);
    }
}
