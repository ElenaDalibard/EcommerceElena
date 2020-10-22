using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionProduitPanier_AspNET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestionProduitPanier_AspNET.Controllers
{
    public class PanierController : Controller
    {
        public IActionResult Index()
        {
            Panier p = new Panier();
            if (HttpContext.Session.GetString("Panier") != null && HttpContext.Session.GetString("Panier") != "")
            {
                p = JsonConvert.DeserializeObject<Panier>(HttpContext.Session.GetString("Panier"));
                if(p.ListeProduits.Count()==0)
                {
                    ViewBag.Message = "Panier est vide";
                }
            }
            else
            {
                ViewBag.Message = "Panier est vide";
            }
            return View(p);
        }
 

        [HttpPost]
        public IActionResult AddProduit(int id, [FromForm]int qty)
        {
            Panier panier = new Panier();
            if(HttpContext.Session.GetString("Panier") != null)
            {
                panier = JsonConvert.DeserializeObject<Panier>(HttpContext.Session.GetString("Panier"));

            }
            Produit produit = Produit.GetProduitById(id);
            if (qty<=produit.Quantity && qty !=0)
            {
                panier.AddProduit(produit, qty);
                HttpContext.Session.SetString("Panier", JsonConvert.SerializeObject(panier));
                return RedirectToAction("Index", panier);
            }
            else
            {
                return RedirectToAction("DetailProduit", "Produit", new { id=produit.Id });
            }
        }
        
        [HttpPost]
        public IActionResult DeleteProduit(int id)
        {
            Panier panier = JsonConvert.DeserializeObject<Panier>(HttpContext.Session.GetString("Panier"));
            Produit produit = Produit.GetProduitById(id);
            panier.ListeProduits.RemoveAll(m => m.Produit.Id == produit.Id);
            HttpContext.Session.SetString("Panier", JsonConvert.SerializeObject(panier));
            return RedirectToAction("Index");
        }
    }
}