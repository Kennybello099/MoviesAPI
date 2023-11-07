using MoviesAPI.Abstraction;
using MoviesAPI.Dtos.Request;
using MoviesAPI.Dtos.Response;
using MoviesAPI.Interface;
using MoviesAPI.Model;
using MoviesAPI.Repository;

namespace MoviesAPI.Service
{
    public class MovieService : IMovieService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<Movies> _logger;
        private readonly IUploadPhoto _uploadPhoto;

        public MovieService(IUnitofWork unitofWork, ILogger<Movies> logger, IUploadPhoto uploadPhoto)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _uploadPhoto = uploadPhoto;
        
        }
        public async Task<ApiResponse<string>> AddMovies(MoviesRequestDto dto)
        {

            try
            {
               if(dto.Rating <= 0)
               {
                    return new ApiResponse<string> { Code = Enum.StatusCodes.BAD_REQUEST, ShortDescription = "You can only rate movie from a scale of 1 to 5." };

               }

                _unitofWork.MoviesRepository.AddMovies(dto);
                await _unitofWork.SaveAsync();

                return new ApiResponse<string> { Code = Enum.StatusCodes.OK, ShortDescription = "Movie has been added successfully." };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "MovieService:: An error occured when  adding movies.");
                //return new ServiceResponse<string> { Code = ResponseCodes.EXCEPTION, ShortDescription = "Something went wrong. Pleas try again later." };
                throw new Exception("Unable to add new movie.");
            }
        }

        public async Task<ApiResponse<string>> DeleteMovie(long Id)
        {
            var getMovie = await _unitofWork.MoviesRepository.GetAsync(x => x.MoviesId == Id);

            if (getMovie == null)
            {
                return new ApiResponse<string> { Code = Enum.StatusCodes.NOT_FOUND, ShortDescription = "Movie does not exist." };
            }

            await _unitofWork.MoviesRepository.DeleteMovie(Id);
            await _unitofWork.SaveAsync();

            return new ApiResponse<string> { Code = Enum.StatusCodes.OK, ShortDescription = "Movie has been deleted successfully." };
        }

        public async Task<ApiResponse<MoviesResponseDto>> GetMovieById(long Id)
        {
            var result = await _unitofWork.MoviesRepository.GetMovieById(Id);
            if (result == null)
            {
                return new ApiResponse<MoviesResponseDto> { Data = null, ShortDescription = "Movie does not exist.", Code = Enum.StatusCodes.NOT_FOUND };

            }
            return new ApiResponse<MoviesResponseDto> { Data = result, Code = Enum.StatusCodes.OK };



        }

        public async Task<ApiResponse<List<MoviesResponseDto>>> GetMovies()
        {
            var result = await _unitofWork.MoviesRepository.GetMovies();
            return new ApiResponse<List<MoviesResponseDto>> { Data = result, Code = Enum.StatusCodes.OK };

        }

        public async Task<ApiResponse<string>> UpdateMovies(long Id, UpdateMoviesDto dto)
        {
            var getMovie = await _unitofWork.MoviesRepository.GetAsync(x => x.MoviesId == Id);

            if (getMovie == null)
            {
                return new ApiResponse<string> { Code = Enum.StatusCodes.NOT_FOUND, ShortDescription = "Movie does not exist." };
            }

            await _unitofWork.MoviesRepository.UpdateMovies(Id, dto);
           await _unitofWork.SaveAsync();

            return new ApiResponse<string> { Code = Enum.StatusCodes.OK, ShortDescription = "Movie has been updated successfully." };

        }

        public async Task<ApiResponse<string>> UploadPhoto(UploadPhoto doc)
        {
            string? fileUrl = null;

            Random generator = new Random();
            var uniqstring = generator.Next(1000000).ToString("D6");

            if (doc != null)
            {
                fileUrl = _uploadPhoto.ProcessUploadedFile(doc.DocumentFile, nameof(Movies), uniqstring ?? "");
            }

            return new ApiResponse<string> { Data = fileUrl, Code = Enum.StatusCodes.OK };
        }
    }
}
