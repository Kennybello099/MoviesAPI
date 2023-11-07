

using MoviesAPI.Abstraction;
using MoviesAPI.Dtos.Request;
using MoviesAPI.Dtos.Response;

namespace MoviesAPI.Service
{
    public interface IMovieService
    {
        Task<ApiResponse<string>> AddMovies(MoviesRequestDto dto);
        Task<ApiResponse<List<MoviesResponseDto>>> GetMovies();
        Task<ApiResponse<MoviesResponseDto>> GetMovieById(long Id);
        Task<ApiResponse<string>>UpdateMovies(long Id, UpdateMoviesDto dto);
        Task<ApiResponse<string>> UploadPhoto(UploadPhoto doc);
        Task<ApiResponse<string>> DeleteMovie(long Id);


    }
}
