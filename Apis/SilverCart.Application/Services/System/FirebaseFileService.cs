using Firebase.Storage;
using Infrastructures.Interfaces.System;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Services.System
{
    public class FirebaseFileService : IFirebaseFileService
    {
        private const string BUCKET_NAME = "save-image-7918c.appspot.com";

        public async Task<string> UploadFIleAsync(IFormFile formFile, string folderName)
        {
            string fileName = Guid.NewGuid().ToString() + "&" + formFile.FileName;
            if (formFile.Length == 0)
            {
                throw new Exception("File is empty");
            }
            var storage = new FirebaseStorage(BUCKET_NAME)
                               .Child(folderName)
                               .Child(fileName);
            await storage.PutAsync(formFile.OpenReadStream());
            var dowloadUrl = await storage.GetDownloadUrlAsync();
            return dowloadUrl;
        }

        public async Task DeleteFileAsync(string fileUrl)
        {
            try
            {
                // Lấy folder name và file name từ URL
                var uri = new Uri(fileUrl);
                var segments = uri.Segments;
                var folderName = segments[^2].TrimEnd('/');
                var fileName = segments[^1];

                var storage = new FirebaseStorage(BUCKET_NAME)
                                   .Child(folderName)
                                   .Child(fileName);

                await storage.DeleteAsync();
            }
            catch (Exception ex)
            {
                // Log lỗi và throw lại exception
                throw new Exception($"Không thể xóa file: {ex.Message}", ex);
            }
        }
    }
}
