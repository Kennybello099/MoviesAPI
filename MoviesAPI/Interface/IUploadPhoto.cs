namespace MoviesAPI.Interface
{
    public interface IUploadPhoto
    {
        string? ProcessUploadedFile(IFormFile iformFile, string className, string name);
    }
}
