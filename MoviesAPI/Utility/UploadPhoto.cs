using MoviesAPI.Interface;

namespace MoviesAPI.Utility
{
    public class UploadPhoto : IUploadPhoto
    {
        private readonly IWebHostEnvironment _environment;
        public UploadPhoto(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public string? ProcessUploadedFile(IFormFile iformFile, string className, string name)
        {
            try
            {

                if (iformFile == null)
                    return null;
                if (string.IsNullOrWhiteSpace(_environment.WebRootPath))
                    _environment.WebRootPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                string uploadsFolder = Path.Combine(_environment.WebRootPath, className);
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);
                string fileExtension = Path.GetExtension(iformFile.FileName);
                if (!fileExtension.EndsWith(".jpeg") && !fileExtension.EndsWith(".jpg") && !fileExtension.EndsWith(".png"))
                {
                    throw new Exception($"You can only upload a photo.");
                }

                string uniqueFileName = string.Concat(DateTime.Now.ToString("yyyy-MM-"), string.Concat(name, $"{fileExtension}"));
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                iformFile.CopyTo(fileStream);
                fileStream.Flush();
                string fileName = Path.GetFileName(filePath);
                string newFilePath = string.Concat("~", "/", className, "/", fileName);
                return newFilePath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error at process file upload {ex}");
            }
        }

    }
}
