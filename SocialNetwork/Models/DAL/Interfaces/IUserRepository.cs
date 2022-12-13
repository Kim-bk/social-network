using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models.DAL.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<List<User>> GetListUsers(List<int> listIds);
        public Task<List<User>> SearchFriend(string userName);
    }
}
