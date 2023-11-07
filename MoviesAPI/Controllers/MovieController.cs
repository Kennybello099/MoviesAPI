using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.ControllerBase;
using MoviesAPI.Dtos.Request;
using MoviesAPI.Service;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ApiControllerBase
    {

        private readonly IMovieService _moviesService;

        public MovieController(IMovieService moviesService)
        {
            _moviesService = moviesService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddMovies([FromBody] MoviesRequestDto dto)
        {
            var result = await _moviesService.AddMovies(dto);
            return ProcessResponse(result);
        }
        [AllowAnonymous]
        [HttpPost("uploadPhoto")]
        public async Task<IActionResult> UploadPhoto([FromForm] UploadPhoto doc)
        {
            var procurementDoc = await _moviesService.UploadPhoto(doc);
            return ProcessResponse(procurementDoc);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetMovie")]
        public async Task<IActionResult> GetMovieById([FromQuery] long Id)
        {
            var result = await _moviesService.GetMovieById(Id);
            return ProcessResponse(result);
        }
        [HttpGet]
        [Route("GetMovies")]
        public async Task<IActionResult> GetMovies()
        {
            var result = await _moviesService.GetMovies();
            return ProcessResponse(result);
        }
        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateMovies(long Id, UpdateMoviesDto dto)
        {
            var result = await _moviesService.UpdateMovies(Id, dto);
            return ProcessResponse(result);
        }
        [AllowAnonymous]
        [HttpDelete]
        [Route("Movie/{Id}")]
        public async Task<IActionResult> DeleteMovie(long Id)
        {
            var result = await _moviesService.DeleteMovie(Id);
            return ProcessResponse(result);
        }
    }
}
