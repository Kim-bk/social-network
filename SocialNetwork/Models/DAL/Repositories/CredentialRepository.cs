using SocialNetwork.Models.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models.DAL.Repositories
{
    public class CredentialRepository : Repository<Credential>, ICredentialRepository
    {
        public CredentialRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }

        public async Task<List<string>> GetCredentialsByUserGroupId(int userGroupId)
        {
            return await GetQuery(cr => cr.UserGroupId == userGroupId && cr.IsActivated == true)
                         .Select(cr => cr.Role.Name)
                         .ToListAsync();
        }

        public async Task<List<Credential>> GetRolesOfUserGroup(int userGroupId)
        {
            return await GetQuery(cr => cr.UserGroupId == userGroupId && cr.IsActivated == true)
                        .ToListAsync();
        }

        public async Task<List<Credential>> GetRolesNotActivated(int userGroupId)
        {
            return await GetQuery(cr => cr.UserGroupId != userGroupId 
                        || (cr.UserGroupId == userGroupId && cr.IsActivated == false))
                        .ToListAsync();
        }
    }
}
