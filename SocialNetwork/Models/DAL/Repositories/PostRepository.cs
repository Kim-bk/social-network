using SocialNetwork.Models.DAL.Interfaces;

namespace SocialNetwork.Models.DAL.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
