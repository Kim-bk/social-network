using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Models.DAL.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        public Task<List<Post>> GetUserPosts(int userId);
        public Task<List<Post>> GetUserFriendPosts(List<int> friendIds);
    }
}
