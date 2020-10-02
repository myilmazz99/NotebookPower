using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ImageCDN
{
    public interface IImageService
    {
        Task Upload(string fileName, IFormFile image);
    }
}
