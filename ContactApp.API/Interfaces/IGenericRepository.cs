using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContactApp.API.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetByIdAsync(object id);
        TEntity GetById(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> JoinWhere(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity,object>>[] includes);
        Task<TEntity> InsertAsyncReturn(TEntity entity);
        Task InsertAsync(TEntity entity);
        void Insert(TEntity entity);
        TEntity InsertReturn(TEntity entity);
        void Delete(TEntity entity);
        void Delete(object id);
        TEntity Update(TEntity entity);
    }
}
