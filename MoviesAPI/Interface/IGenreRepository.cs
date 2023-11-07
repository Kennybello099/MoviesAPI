using MoviesAPI.Dtos.Response;
using MoviesAPI.Model;

namespace MoviesAPI.Interface
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<List<Genre>> GetGenres();
        Task<Genre> GetGenre(long Id);
    }
}
