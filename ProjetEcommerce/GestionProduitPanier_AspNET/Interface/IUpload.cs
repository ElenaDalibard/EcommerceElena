using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Interface
{
    public interface IUpload
    {
        string UploadImage(IFormFile file);
    }
}
