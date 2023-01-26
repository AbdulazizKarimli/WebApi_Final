using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Business.HelperServices.Interfaces;

public interface IFileService
{
    Task<string> CopyFileAsync(IFormFile file,string wwwroot, params string[] folders);
}
