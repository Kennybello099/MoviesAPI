using MoviesAPI.Interface;
using MoviesAPI.Migration;

namespace MoviesAPI.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly Migration.ApplicationData _context;
        public IMovieRepository MoviesRepository { get; set; }
        public UnitofWork(ApplicationData context, IMovieRepository moviesRepository)
        {
            _context = context;
            MoviesRepository = moviesRepository;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
