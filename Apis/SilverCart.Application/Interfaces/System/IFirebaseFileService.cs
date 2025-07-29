using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.System
{
    public interface IFirebaseFileService
    {
        public Task<string> UploadFIleAsync(IFormFile formFile, string folderName);
    }
}
