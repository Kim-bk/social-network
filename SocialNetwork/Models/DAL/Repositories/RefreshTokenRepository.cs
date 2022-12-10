using SocialNetwork.Models.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SocialNetwork.Models.DAL.Repositories
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task DeleteAll(int userId)
        {
            var listTokens = await GetQuery(u => u.UserId == userId).ToListAsync();
            Delete(listTokens);
        }
    }
}
