namespace MoviesAPI.Interface
{
    public interface IUnitofWork : IDisposable
    {
        IMovieRepository MoviesRepository { get; set; }
        Task<int> SaveAsync();
    }
}
