using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Olm.Model.Entities;

namespace Olm.Service.Interfaces
{
    public interface IService<TEntity>
        where TEntity : BaseEntity
    {
        Task Add(TEntity entity);

        Task<TEntity> Get(Guid id);

        Task<IList<TEntity>> GetAll();

        Task<IList<TEntity>> GetMany(IList<Guid> entityIds);

        Task Update(TEntity entity);

        Task Update(IList<TEntity> entities);

        Task Remove(Guid id);

        Task RemoveMultiple(IList<TEntity> entities, Guid? updaterId);

        IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> filterExpression = null);
    }
}