using MoviesAPI.Abstraction;
using MoviesAPI.Dtos.Request;
using MoviesAPI.Dtos.Response;
using MoviesAPI.Model;

namespace MoviesAPI.Interface
{
    public interface IMovieRepository : IGenericRepository<Movies>
    {
        void AddMovies(MoviesRequestDto dto);
        Task<List<MoviesResponseDto>> GetMovies();
        Task<MoviesResponseDto> GetMovieById(long Id);

        Task UpdateMovies(long Id, UpdateMoviesDto dto);

        Task DeleteMovie(long Id);


    }
}
