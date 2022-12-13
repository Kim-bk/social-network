using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<List<User>> GetListUsers(List<int> listIds)
        {
            return await GetQuery(us => listIds.Contains(us.Id)).ToListAsync();
        }

        public async Task<List<User>> SearchFriend(string userName)
        {
            return await GetQuery(us => us.Name.ToLower().Contains(userName.ToLower())).ToListAsync();
        }
    }
}
