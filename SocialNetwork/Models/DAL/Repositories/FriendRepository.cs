using SocialNetwork.Models.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Models.DAL.Repositories
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {
        public FriendRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }

        public async Task<List<int>> GetFriendsOfUser(int userId)
        {
            return await GetQuery(us => us.SourceId == userId)
                .Select(f => f.TargetId)
                .ToListAsync();
        }
    }
}
