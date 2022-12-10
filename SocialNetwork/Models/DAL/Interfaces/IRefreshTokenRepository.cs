using System.Threading.Tasks;

namespace SocialNetwork.Models.DAL.Interfaces
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
        public Task DeleteAll(int userId);
    }
}
