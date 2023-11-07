namespace MoviesAPI.Abstraction
{
    public sealed class ApiResponse<TResponse> where TResponse : class
    {
        public MoviesAPI.Enum.StatusCodes Code { get; set; } = Enum.StatusCodes.OK;
        public string? ShortDescription { get; set; } = "Successful";
        public TResponse? Data { get; set; }
    }
}
