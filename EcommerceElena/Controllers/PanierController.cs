using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceElena.DataAccess;
using EcommerceElena.Models;

namespace EcommerceElena.Controllers
{
    [Authorize]
    public class PanierController : Controller
    {
        Commande Panier;
        double livraison = 0;
        double uniteLivraison = 3;

        public PanierController()
        {
            Panier = (Commande)System.Web.HttpContext.Current.Session["Panier"];

            if(Panier.User==null)
            {
                Panier.User = (User)System.Web.HttpContext.Current.Session["User"];
                System.Web.HttpContext.Current.Session["Panier"] = Panier;
            }
        }

        public ActionResult Ajouter(int id)
        {
            Repository<Produit> repProd = new EFRepository<Produit>();

            DetailCommande detail;

            if (Panier.DetailCommandes.Where(d => d.idProd == id).Count() > 0)
            {
                detail = Panier.DetailCommandes.Where(d => d.idProd == id).First();
                detail.quantite++;
            }
            else
            {
                detail = new DetailCommande { Produit = repProd.Trouver(id), idProd = id, quantite = 1 };
                Panier.DetailCommandes.Add(detail);
        }
        Session["Panier"] = Panier;
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
                return View(Panier);
        }

        public ContentResult Incrementer(int id)
        {
            DetailCommande detailActif = Panier.DetailCommandes.Where(d => d.idProd == id).First();
            detailActif.quantite++;
            return new ContentResult()
            {
                Content = string.Format("<span class=\"col-md-4 col-md-offset-2\">{0}</span><span class=\"col-md-4\">{1} €</span>", detailActif.quantite.ToString(), detailActif.quantite * detailActif.Produit.PrixProd)
            };
        }

        public ContentResult Decrementer(int id)
        {
            DetailCommande detailActif = Panier.DetailCommandes.Where(d => d.idProd == id).First();
            if(detailActif.quantite>1)
            {
                detailActif.quantite--;
            }
            return new ContentResult()
            {
                Content = string.Format("<span class=\"col-md-4 col-md-offset-2\">{0}</span><span class=\"col-md-4\">{1} €</span>", detailActif.quantite.ToString(), detailActif.quantite * detailActif.Produit.PrixProd)
            };
        }


        public ContentResult Supprimer(int id)
        {
            Panier.DetailCommandes.Remove(Panier.DetailCommandes.Where(d => d.idProd == id).First());
            return new ContentResult();
        }

        public ContentResult CalculerTotal()
        {
            return new ContentResult()
            {
                Content = Panier.DetailCommandes.Select(d => new { montant = d.Produit.PrixProd * d.quantite }).Sum(m => m.montant).ToString()
            };
        }

        public ContentResult Livraison()
        {
            double? poidsTotal = Panier.DetailCommandes.Select(d => new { poidsTotal = d.Produit.poids * d.quantite }).Sum(m => m.poidsTotal);
            livraison = (int)(poidsTotal / 1.5) * uniteLivraison;

            return new ContentResult()
            {
                Content = livraison.ToString()
            };
        }


        public ContentResult TotalAvecLivraison()
        {
            double? total = Panier.DetailCommandes.Select(d => new { total = d.Produit.PrixProd * d.quantite }).Sum(m => m.total);
            double? poidsTotal = Panier.DetailCommandes.Select(d => new { poidsTotal = d.Produit.poids * d.quantite }).Sum(m => m.poidsTotal);
            livraison = (int)(poidsTotal / 1.5) * uniteLivraison;

            return new ContentResult()
            {
                Content = (livraison + total).ToString()
            };
        }
    }
}
