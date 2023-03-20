using System.Drawing.Drawing2D;
using System.Drawing;

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
        public static string UploadImagesWithSize(IFormFile file, string FolderName, int newSize = 480)
        {
            try
            {
                if (!Directory.Exists($"~/UploadedFiles/{FolderName}"))
                {
                    Directory.CreateDirectory($"~/UploadedFiles/{FolderName}");
                }
                Image originalImage = Image.FromStream(file.OpenReadStream());


                Guid g = Guid.NewGuid();
                string filename = g.ToString();
                filename += Path.GetExtension(file.FileName);
                filename = $"~/UploadedFiles/{FolderName}/{filename}";
                string path = Path.Combine(filename);


                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                    {
                        resizeImage(originalImage, new Size(480, 480)).
                            Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                return filename;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)

        {

            //Get the image current width

            int sourceWidth = imgToResize.Width;

            //Get the image current height

            int sourceHeight = imgToResize.Height;



            float nPercent = 0;

            float nPercentW = 0;

            float nPercentH = 0;

            //Calulate  width with new desired size

            nPercentW = ((float)size.Width / (float)sourceWidth);

            //Calculate height with new desired size

            nPercentH = ((float)size.Height / (float)sourceHeight);



            if (nPercentH < nPercentW)

                nPercent = nPercentH;

            else

                nPercent = nPercentW;

            //New Width

            int destWidth = (int)(sourceWidth * nPercent);

            //New Height

            int destHeight = (int)(sourceHeight * nPercent);



            Bitmap b = new Bitmap(destWidth, destHeight);

            Graphics g = Graphics.FromImage((System.Drawing.Image)b);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw image with new width and height

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);

            g.Dispose();

            return (System.Drawing.Image)b;

        }
    }
}
