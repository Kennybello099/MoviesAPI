using MoviesAPI.Enum;
using MoviesAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Dtos.Request
{
    public class MoviesRequestDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [Required]
        public decimal TicketPrice { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public List<GenreDtocs> TheGenre { get; set; }
        [Required]
        public string? Photo { get; set; }
        public MoviesRequestDto()
        {
            TheGenre = new List<GenreDtocs>();
        }


    }
    public class UpdateMoviesDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }


        public Rating Rating { get; set; }

        public decimal TicketPrice { get; set; }

        public string? Country { get; set; }

        public List<UpdateGenreDto> Genre { get; set; }
        public string? Photo { get; set; }
        public UpdateMoviesDto()
        {
            Genre = new List<UpdateGenreDto>();
        }
    }
}
