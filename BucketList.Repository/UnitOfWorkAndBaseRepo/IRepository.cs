using BucketList.Common.StaticConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BucketList.Repository.UnitOfWorkAndBaseRepo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Alter(TEntity entityToUpdate);

        int Count(Expression<Func<TEntity, bool>> predicate);

        //#############Async###########################
        Task<TEntity> GetAsync(long id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, string includeProperties = "");
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null,
                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                        string includeProperties = "", int page = Constants.DefaultPageNo, int pageSize = Constants.DefaultPageSize);

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
