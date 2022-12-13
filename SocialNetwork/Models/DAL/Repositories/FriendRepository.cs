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

        public async Task<bool> CheckFriend(int userId, int friendId)
        {
            return await GetQuery(us => us.SourceId == userId && us.TargetId == friendId).FirstOrDefaultAsync() != null;
          
    }

        public async Task<List<int>> GetFriendsOfUser(int userId)
        {
            var result = new List<int>();
            var rs = await GetQuery(us => us.SourceId == userId && us.Status == true)
                .Select(f => f.TargetId)
                .ToListAsync();

            var rs2 = await GetQuery(us => us.TargetId == userId && us.Status == true)
                .Select(f => f.SourceId)
                .ToListAsync();

            result.AddRange(rs);
            result.AddRange(rs2);

            return result;
        }

        public async Task<List<int>> GetInvitationFriendsOfUser(int userId)
        {
            var result = new List<int>();
            var rs = await GetQuery(us => us.SourceId == userId && us.Status == false)
                .Select(f => f.TargetId)
                .ToListAsync();

            var rs2 = await GetQuery(us => us.TargetId == userId && us.Status == false)
                .Select(f => f.SourceId)
                .ToListAsync();

            result.AddRange(rs);
            result.AddRange(rs2);

            return result;
        }
    }
}
