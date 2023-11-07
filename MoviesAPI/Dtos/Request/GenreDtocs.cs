using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesAPI.Dtos.Request
{
    public class GenreDtocs
    {
        [Required]
        public string? Name { get; set; }

        [JsonIgnore]
        public long GenreId { get; set; }
    }
    public class GenreDto
    {
        public string? Name { get; set; }

    }
    public class UpdateGenreDto
    {
        public string? Name { get; set; }
        public long? GenreId { get; set; }


    }


}
