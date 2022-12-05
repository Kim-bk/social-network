using System;

namespace SocialNetwork.Models.DAL
{
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private Func<SocialNetworkContext> _instanceFunc;
        private SocialNetworkContext _dbContext;
        public SocialNetworkContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());

        public DbFactory(Func<SocialNetworkContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
