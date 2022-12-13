using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SocialNetwork.Models.DAL.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<List<Post>> GetUserFriendPosts(List<int> friendIds)
        {
            List<Post> result = new();
            foreach (var id in friendIds)
            {
                result.AddRange(await GetUserPosts(id));
            }
            return result;
        }

        public async Task<List<Post>> GetUserPosts(int userId)
        {
            return await GetQuery(p => p.User.Id == userId).ToListAsync();
        }
    }
}
