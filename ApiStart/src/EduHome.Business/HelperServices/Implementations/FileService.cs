using EduHome.Business.Exceptions;
using EduHome.Business.HelperServices.Interfaces;
using EduHome.Business.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Business.HelperServices.Implementations
{
    public class FileService : IFileService
    {
        public async Task<string> CopyFileAsync(IFormFile file, string wwwroot, params string[] folders)
        {
            string filename = String.Empty;
            
            if (file != null)
            {
                if (!file.CheckFileFormat("image/"))
                {
                    throw new IncorrectFileFormatException("Incorrect file format");
                }
                if (!file.CheckFileSize(100))
                {
                    throw new IncorrectFileSizeException("Incorrect file size");
                }

                filename = Guid.NewGuid().ToString() + file.FileName;
                string resultPath = wwwroot;
                foreach (var folder in folders)
                {
                    resultPath = Path.Combine(resultPath,folder);
                }
                resultPath = Path.Combine(resultPath, filename);
                using (FileStream stream = new FileStream(resultPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return filename;
            }
            throw new Exception();
        }
    }
}
