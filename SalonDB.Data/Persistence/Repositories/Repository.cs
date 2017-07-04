using SalonDB.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalonDB.Data.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        internal DbSet<TEntity> _Entities;

        public Repository(DbContext context)
        {
            Context = context;
            _Entities = Context.Set<TEntity>();
        }

        public TEntity Get(Guid id)
        {
            return _Entities.Find(id);
        }
        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _Entities.FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _Entities.ToList();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _Entities.ToListAsync();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Entities.SingleOrDefault(predicate);
        }
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _Entities.SingleOrDefaultAsync(match);
        }


        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _Entities.Where(predicate);
        }
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _Entities.Where(match).ToListAsync();
        }


        public void Add(TEntity entity)
        {
            _Entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _Entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _Entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _Entities.RemoveRange(entities);
        }
    }
}
