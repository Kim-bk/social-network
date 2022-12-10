using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models.DAL;

namespace SocialNetwork.Models.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbFactory _dbFactory;
        private DbSet<T> _dbSet;

        private DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }

        public Repository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }
        public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }
        public async Task<T> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }
        public async Task Delete(Expression<Func<T, bool>> expression)
        {
            T entity = await FindAsync(expression);
            DbSet.Remove(entity);
        }
        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
        public void Delete(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }
        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await DbSet.FirstOrDefaultAsync(expression);
        }
    }
}
