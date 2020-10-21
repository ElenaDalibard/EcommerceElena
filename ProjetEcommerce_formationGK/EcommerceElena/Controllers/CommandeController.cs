using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceElena.DataAcces;
using EcommerceElena.DataAccess;
using EcommerceElena.Models;
using EcommerceElena.Outils;

namespace EcommerceElena.Controllers
{
    [Authorize]
    public class CommandeController : Controller
    {
        CommandeRepository repCommande = new CommandeRepository();

        public ActionResult Confirmation()
        {
            try
            { 
            ViewBag.Total = float.Parse((new PanierController()).TotalAvecLivraison().Content);
            return View((Commande)System.Web.HttpContext.Current.Session["Panier"]);
            }
            catch
            {
                return View("Login", "Account");
            }
        }

        public ActionResult Validation()
        {
            CommandeRepository repCommande = new CommandeRepository();
            Commande Panier = (Commande)System.Web.HttpContext.Current.Session["Panier"];
            try
            {
                Panier.dateCommande = DateTime.Now;
                Panier.PrixTotal = float.Parse((new PanierController()).TotalAvecLivraison().Content);
                Commande cmd = repCommande.Ajouter(Panier);
                System.Web.HttpContext.Current.Session["Panier"] = new Commande();
                return View("Validation", Panier);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Lister()
        {
            return View(repCommande.Lister().OrderByDescending(p=>p.dateCommande));
        }

        public ActionResult ListFiltre()
        {
            return View(repCommande.Lister().Where(c => c.statusCommande != 0).OrderBy(c => c.statusCommande));
        }
        
        public ActionResult ListInactive()
        {
            return View(repCommande.Lister().Where(c => c.statusCommande == 0).OrderByDescending(p => p.dateCommande));
        }

        public ActionResult Details(int id)
        {
            return View(repCommande.Trouver(id));
        }

        public ContentResult Inactiver(int id)
        {
            Commande cmdInactive = repCommande.Trouver(id);
            cmdInactive.statusCommande = (int)StatusCommande.inactive;
            repCommande.Modifier(cmdInactive);
            return new ContentResult
            {
                Content = ((StatusCommande)cmdInactive.statusCommande).ToString()
            };
        }

        public ContentResult Supprimer(int id)
        {
            repCommande.Supprimer(id);
            return new ContentResult();
        }

        public ContentResult Traiter(int id)
        {
            Commande cmdTraiter = repCommande.Trouver(id);

            if(cmdTraiter.statusCommande<(int)StatusCommande.livrée)
            {
                cmdTraiter.statusCommande++;
                repCommande.Modifier(cmdTraiter);
            }
            return new ContentResult
            {
                Content = ((StatusCommande)cmdTraiter.statusCommande).ToString()
            };
        }
    }
}
