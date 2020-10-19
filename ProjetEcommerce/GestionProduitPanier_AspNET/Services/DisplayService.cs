using GestionProduitPanier_AspNET.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Services
{
    public class DisplayService : IDisplayer
    {
        private IHttpContextAccessor accessor;
        public DisplayService(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;
        }
        public string ReWriteImageUrl(string url)
        {
            string host = accessor.HttpContext.Request.Scheme + "://"+ accessor.HttpContext.Request.Host.Value;


            if(url.Contains("http"))
            {
                return url;
            }
            else
            {
                //return "http://localhost:64022/" + url;
                return host + "/" +url;
            }
        }
    }
}
