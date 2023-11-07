using MoviesAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Model
{
    public class Movies
    {
        public long MoviesId { get; set; } 
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Rating Rating { get; set; }

        public decimal TicketPrice { get; set; }

        public string? Country { get; set; }

        public  virtual ICollection<Genre> TheGenre { get; set; }
        public string? Photo { get; set; }

        public bool IsDeleted { get; set; }
    }
}
