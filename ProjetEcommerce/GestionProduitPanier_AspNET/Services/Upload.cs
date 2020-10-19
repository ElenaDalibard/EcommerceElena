using GestionProduitPanier_AspNET.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Services
{
    public class UploadService : IUpload
    {
        IWebHostEnvironment env;
        public UploadService(IWebHostEnvironment _env)
        {
            env = _env;
        }
        public string UploadImage(IFormFile image)
        {
            string uniqueString = Guid.NewGuid().ToString();
            string basePath = "Images/" + uniqueString + "-" + image.FileName;
            string path = Path.Combine(env.WebRootPath, basePath);
            Stream s = System.IO.File.Create(path);
            image.CopyTo(s);
            s.Close();
            return basePath;
        }
    }
}
