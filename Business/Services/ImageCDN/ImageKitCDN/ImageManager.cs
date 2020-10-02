using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Extensions;
using Imagekit;
using Microsoft.AspNetCore.Http;

namespace Business.Services.ImageCDN.ImageKitCDN
{
    public class ImageManager : IImageService
    {
        private readonly Imagekit.Imagekit imagekit = new Imagekit.Imagekit(Keys.PublicKey, Keys.SecretKey, Keys.UrlEndpoint, "path");
        
        public async Task Upload(string fileName, IFormFile image)
        {
            imagekit.FileName(fileName).Upload(await image.GetBytes());
        }
    }
}
