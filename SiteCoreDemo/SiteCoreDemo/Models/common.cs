namespace SiteCoreDemo.Models
{
    public static class common
    {
        public static string UploadImages(IFormFile file, string FolderName)
        {
            try
            {
                if (!Directory.Exists($"~/UploadedFiles/{FolderName}"))
                {
                    Directory.CreateDirectory($"~/UploadedFiles/{FolderName}");
                }

                Guid g = Guid.NewGuid();
                string filename = g.ToString();
                filename += Path.GetExtension(file.FileName);
                filename = $"~/UploadedFiles/{FolderName}/{filename}";
                string path = Path.Combine(filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return filename;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
