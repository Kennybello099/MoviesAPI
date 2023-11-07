using System.Linq.Expressions;

namespace MoviesAPI.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity? Get();
        Task<TEntity?> GetAsync();
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>? includePredicate = null);
        Task InsertAsync(TEntity entity);
        Task InsertAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(TEntity[] entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
    }
}
