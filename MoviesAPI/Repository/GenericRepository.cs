using Microsoft.EntityFrameworkCore;
using MoviesAPI.Interface;
using MoviesAPI.Migration;
using System.Linq.Expressions;

namespace MoviesAPI.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        protected readonly ApplicationData _context;

        protected GenericRepository(ApplicationData context)
        {
            _context = context;
        }
        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>();
        public async Task<TEntity?> GetAsync() => await _context.Set<TEntity>().FirstOrDefaultAsync();
        public TEntity? Get() => _context.Set<TEntity>().FirstOrDefault();
        public TEntity? Get(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Where(predicate).FirstOrDefault();
        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>().Where(predicate).ToListAsync();
        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>? includePredicate = null) => includePredicate == null ? await _context.Set<TEntity>().ToListAsync() : await _context.Set<TEntity>().Include(includePredicate).ToListAsync();
        public async Task InsertAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);
        public async Task InsertAsync(IEnumerable<TEntity> entities) => await _context.Set<TEntity>().AddRangeAsync(entities);
        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);
        public void Delete(TEntity[] entities) => _context.Set<TEntity>().RemoveRange(entities);
        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
        // public void Update(TEntity[] entities) => _context.Set<TEntity>().UpdateRange(entities);
        public bool Exists(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Any(predicate);

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Where(predicate);

        public void Update(IEnumerable<TEntity> entities) => _context.Set<TEntity>().UpdateRange(entities);
    }
}
