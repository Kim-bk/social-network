using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SocialNetwork.Models;
using SocialNetwork.Models.DAL;

namespace SocialNetwork.Models.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialNetworkContext _dbContext;
        private IDbContextTransaction _transaction;
        private readonly IsolationLevel? _isolationLevel;

        public bool HasActiveTransaction => _transaction != null;

        public UnitOfWork(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task StartNewTransactionIfNeeded()
        {
            if (_transaction == null)
            {
                _transaction = _isolationLevel.HasValue ?
                    await _dbContext.Database.BeginTransactionAsync(_isolationLevel.GetValueOrDefault()) : await _dbContext.Database.BeginTransactionAsync();
            }
        }

        public async Task BeginTransaction()
        {
            await StartNewTransactionIfNeeded();
        }

        public async Task CommitTransaction()
        {
            /*
             do not open transaction here, because if during the request
             nothing was changed(only select queries were run), we don't
             want to open and commit an empty transaction -calling SaveChanges()
             on _transactionProvider will not send any sql to database in such case
            */

            await _dbContext.SaveChangesAsync();

            if (_transaction == null) return;

            await _transaction.CommitAsync();

            await _transaction.DisposeAsync();
            _transaction = null;
        }
        public async Task RollbackTransaction()
        {

            if (_transaction == null) return;

            await _transaction.RollbackAsync();

            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public void Dispose()
        {
            if (_dbContext == null)
                return;
            // Close connection
          
            _dbContext.Dispose();
        }
    }
}
