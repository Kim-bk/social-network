using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Models.DAL.Interfaces
{
    public interface ICredentialRepository : IRepository<Credential>
    {
        Task<List<string>> GetCredentialsByUserGroupId(int userGroupId);

        Task<List<Credential>> GetRolesOfUserGroup(int userGroupId);

        Task<List<Credential>> GetRolesNotActivated(int userGroupId);
    }
}
