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
        public async Task<string> UploadFIleAsync(IFormFile formFile, string folderName)
        {
            string fileName = Guid.NewGuid().ToString() + "&" + formFile.FileName;
            if (formFile.Length == 0)
            {
                throw new Exception("File is empty");
            }
            var storage = new FirebaseStorage("save-image-7918c.appspot.com")
                               .Child(folderName)
                               .Child(fileName);
            await storage.PutAsync(formFile.OpenReadStream());
            var dowloadUrl = await storage.GetDownloadUrlAsync();
            return dowloadUrl;
        }
    }
}
