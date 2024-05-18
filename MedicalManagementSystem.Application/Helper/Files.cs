using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace MedicalManagementSystem.Application.Helper
{
    public class Files
    {
        public const string masterFolderName = "api/files";
        public static string UploadFiles(IFormFile image, string? folderName = null)
        {
            folderName = Path.Combine(masterFolderName, folderName!);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (image.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName!.Trim('"');
                var dbPath = DateTime.Now.Ticks + Path.GetExtension(fileName);
                var fullPath = Path.Combine(pathToSave, dbPath);
                using (var stream = new FileStream(fullPath, FileMode.Create)) image.CopyTo(stream);
                return dbPath;
            }
            else return "Error while uploading image";
        }

        public static byte[] GetImage(string root, string fileName) => !File.Exists(root + fileName)
                ? File.ReadAllBytes($"{root}/noImage.jpg")
                : File.ReadAllBytes(root + fileName);
    }
}
