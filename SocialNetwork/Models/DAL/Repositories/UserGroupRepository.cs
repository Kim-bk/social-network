using SocialNetwork.Models;
using SocialNetwork.Models.DAL.Interfaces;

namespace SocialNetwork.Models.DAL.Repositories
{
    public class UserGroupRepository : Repository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
