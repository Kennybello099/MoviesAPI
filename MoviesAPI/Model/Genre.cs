namespace MoviesAPI.Model
{
    public class Genre
    {
        public long GenreId { get; set; }
        public string? Name { get; set; }
        public long? MoviesId { get; set; }
        public virtual Movies? Movies { get; set; }

    }
}
