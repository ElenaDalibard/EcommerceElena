using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GestionProduitPanier_AspNET.Interface;
using GestionProduitPanier_AspNET.Models;
using GestionProduitPanier_AspNET.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestionProduitPanier_AspNET.Controllers
{
    public class ProduitController : Controller
    {
        private IUpload service;
        private ITranslate translation;
        ISaveErreurs errors;

        public ProduitController(IUpload _service, ITranslate _translation, ISaveErreurs _errors)
        {
            service = _service;
            translation = _translation;
            errors = _errors;
        }
        public IActionResult Acceuil(string titre)
        {
            ProduitsViewModel vm = new ProduitsViewModel();
            try
            {
                vm.produits = Produit.GetProduitsByTitre(titre);
                if (HttpContext.Session.GetString("Langue") == null)
                {
                    HttpContext.Session.SetString("Langue", "FR");
                }
            }
            catch(Exception ex)
            {
                errors.WriteErrors(ex);
            }
            return View(vm);
        }

        public IActionResult DetailProduit(int id)
        {
            Produit produit = Produit.GetProduitById(id);
            return View(produit);
        }

        [HttpGet]
        [Authorize(Policy = "ConnectAdmin")]
        public IActionResult AddProduit(int id =0)
        {
            Produit produit;
            if(id==0)
            {
                produit = new Produit();
                produit.Images = new List<Image>();
            }
            else
            {
                produit = Produit.GetProduitById(id);
            }
            return View(produit);
        }

        [HttpPost]
        public IActionResult SubmitProduit([FromForm]Produit produit, [FromForm]List<IFormFile> images)
        {
            try
            {
                if (produit.Id != 0)
                {
                    Produit p = Produit.GetProduitById(produit.Id);
                    produit.Images = p.Images;
                    produit.Update();
                }
                else
                {
                    produit.Save();
                }
                foreach (IFormFile i in images)
                {
                    Image image = new Image()
                    {
                        Url = service.UploadImage(i),
                    };
                    produit.Images.Add(image);
                    produit.Update();
                }
            }
            catch(Exception ex)
            {
                errors.WriteErrors(ex);
            }
                return RedirectToAction("Acceuil");
        }

        [HttpGet]
        [Authorize(Policy = "ConnectAdmin")]
        public IActionResult EditProduit(int id)
        {
            Produit p = Produit.GetProduitById(id);
            return RedirectToAction("AddProduit", new { id = p.Id});
        }

        [HttpGet]
        [Authorize(Policy = "ConnectAdmin")]
        public IActionResult DeleteProduit(int id)
        {
            Produit p = Produit.GetProduitById(id);
            p.Delete();
            return RedirectToAction("Acceuil");
        }

        [HttpPost]
        public IActionResult DeleteImage(int id_Image)
        {
            Produit p = Produit.GetProduitByImage(id_Image);
            p.Images.Remove(Image.GetImageById(id_Image));
            p.Update();
            return RedirectToAction("AddProduit", new { id = p.Id });
        }

        [HttpPost]
        public IActionResult SetLangue(string langue)
        {
            translation.ChangeLangue(langue);
            return RedirectToAction("Acceuil");
        }
    }
}