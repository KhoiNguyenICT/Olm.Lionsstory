using Microsoft.EntityFrameworkCore;
using Olm.Model;
using Olm.Model.Entities;
using Olm.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Olm.Service.Implementations
{
    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Guid id)
        {
            var entity = await _context.Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<TEntity>> GetAll()
        {
            var entities = await _context.Set<TEntity>()
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
            return entities;
        }

        public async Task<IList<TEntity>> GetMany(IList<Guid> entityIds)
        {
            var entities = await _context.Set<TEntity>()
                .AsNoTracking()
                .Where(x => entityIds.Contains(x.Id))
                .ToListAsync();
            return entities;
        }

        public async Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Update(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMultiple(IList<TEntity> entities, Guid? updaterId)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> filterExpression = null)
        {
            if (filterExpression == null) return _context.Set<TEntity>().AsNoTracking();
            return _context.Set<TEntity>().AsNoTracking().Where(filterExpression);
        }
    }
}