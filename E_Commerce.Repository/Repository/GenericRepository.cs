
using E_Commerce.Data.Context;
using E_Commerce.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context) { 
        _context = context;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            return  _context.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual  void Update(TEntity entity)
        {
             _context.Set<TEntity>().AddOrUpdate(entity);
        }
    }
}
