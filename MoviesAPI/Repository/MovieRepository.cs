using Azure.Core;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Abstraction;
using MoviesAPI.Dtos.Request;
using MoviesAPI.Dtos.Response;
using MoviesAPI.Interface;
using MoviesAPI.Migration;
using MoviesAPI.Model;

namespace MoviesAPI.Repository
{
    public class MovieRepository : GenericRepository<Movies>, IMovieRepository
    {
        public MovieRepository(ApplicationData _context) : base(_context)
        {

        }

        public void AddMovies(MoviesRequestDto dto)
        {

            var request = new Movies()
            {
                Name = dto.Name?.Trim(),
                Description = dto.Description?.Trim(),
                ReleaseDate = DateTime.UtcNow,
                Rating = dto.Rating,
                TicketPrice = dto.TicketPrice,
                Country = dto.Country?.Trim(),
                Photo = dto.Photo?.Trim()
            };
            var genres = new List<Genre>();

            foreach (var item in dto.TheGenre)
            {
                var genre = new Genre();
                genre.Name = item.Name;
                genres.Add(genre);
            }
            request.TheGenre = genres;
            _context.Movies?.Add(request);
        }

        public async Task DeleteMovie(long Id)
        {
            var movie = await _context.Movies
                 .Include(i => i.TheGenre)
                 .FirstOrDefaultAsync(s => s.MoviesId == Id);


            foreach (var item in movie.TheGenre)
            {
                var genre = _context.Genre
                    .FirstOrDefault(t => t.MoviesId == Id
                                      && t.GenreId == item.GenreId);

                movie.IsDeleted = true;
                movie.TheGenre.Remove(genre);

            };
        }

        public Task<MoviesResponseDto> GetMovieById(long Id)
        {
            var moviebyId = from movies in _context.Movies
                            where movies.MoviesId == Id  && movies.IsDeleted == false

                            select new MoviesResponseDto
                            {
                                MovieId = movies.MoviesId,
                                Name = movies.Name,
                                Description = movies.Description,
                                Country = movies.Country,
                                TicketPrice = movies.TicketPrice,
                                ReleaseDate = movies.ReleaseDate,
                                Rating = movies.Rating,
                                Photo = movies.Photo,
                                Genres = movies.TheGenre.Where(s => s.GenreId != 0)
                                      .Select(s => new GenreDtocs
                                      {
                                          GenreId = s.GenreId,
                                          Name = s.Name,
                                      })

                            };
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return moviebyId.FirstOrDefaultAsync();
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        public async Task<List<MoviesResponseDto>> GetMovies()
        {
            var moviebyId = from movies in _context.Movies
                            where movies.IsDeleted == false                            

                            select new MoviesResponseDto
                            {
                                MovieId = movies.MoviesId,
                                Name = movies.Name,
                                Description = movies.Description,
                                Country = movies.Country,
                                TicketPrice = movies.TicketPrice,
                                ReleaseDate = movies.ReleaseDate,
                                Rating = movies.Rating,
                                Photo = movies.Photo,
                                Genres = movies.TheGenre.Where(s => s.GenreId != 0)
                                      .Select(s => new GenreDtocs
                                      {
                                          GenreId = s.GenreId,
                                          Name = s.Name,
                                      })

                            };
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return moviebyId.OrderByDescending(x=>x.ReleaseDate).ToList();
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        public async Task UpdateMovies(long Id, UpdateMoviesDto dto)
        {
            var movie = await _context.Movies
                .Include(i => i.TheGenre)
                .FirstOrDefaultAsync(s => s.MoviesId == Id);

            movie.Name = dto.Name;
            movie.Description = dto.Description;
            movie.Country = dto.Country;
            movie.TicketPrice = dto.TicketPrice;
            movie.ModifiedDate = DateTime.Now;
            if (!string.IsNullOrEmpty(dto.Photo))
                movie.Photo = dto.Photo;
            if (!string.IsNullOrWhiteSpace(dto.Rating.ToString()))
                movie.Rating = dto.Rating;


            foreach (var item in dto.Genre)
            {
                var genre = _context.Genre
                    .FirstOrDefault(t => t.MoviesId == Id
                                      && t.GenreId == item.GenreId);

                genre.Name = item.Name;

                movie.TheGenre.Add(genre);

            };
        }
    }
    
}
