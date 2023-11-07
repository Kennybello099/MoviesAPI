using MoviesAPI.Dtos.Request;
using MoviesAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Dtos.Response
{
    public class MoviesResponseDto
    {
        public long MovieId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Rating Rating { get; set; }
        public decimal TicketPrice { get; set; }
        public string? Country { get; set; }
        public string? Photo { get; set; }

        public DateTime ReleaseDate { get; set; }
        public IEnumerable<GenreDtocs>? Genres { get; set; }
    }
}
