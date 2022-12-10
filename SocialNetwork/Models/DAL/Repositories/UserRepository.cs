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

        public async Task<User> GetNameUser(int idShop)
        {
            return await GetQuery(sh => sh.ShopId == idShop).FirstOrDefaultAsync();
        }
    }
}
