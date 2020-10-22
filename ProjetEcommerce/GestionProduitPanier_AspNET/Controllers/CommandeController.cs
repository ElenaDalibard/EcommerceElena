using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GestionProduitPanier_AspNET.Models;
using GestionProduitPanier_AspNET.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestionProduitPanier_AspNET.Controllers
{
    public class CommandeController : Controller
    {
        [Authorize(Policy = "ConnectAdmin")]
        public IActionResult AllCommandes()
        {
            return View(Commande.GetCommandes());
        }

        [Authorize(Policy = "ConnectUser")]
        public IActionResult CommandesClient()
        {
            List<Commande> commandes = new List<Commande>();
            Utilisateur user = Utilisateur.GetUserByEmail(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value);
            commandes = Commande.GetCommandeByClient(user.Id);
            return View(commandes);
        }

        [Authorize(Policy = "ConnectUser")]
        public IActionResult PasserCommande()
        {
            Commande commande = new Commande();
            Panier panier = JsonConvert.DeserializeObject<Panier>(HttpContext.Session.GetString("Panier"));
            Utilisateur user = Utilisateur.GetUserByEmail(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value);
            commande.Save(panier, user);
            foreach(ProduitCommande pc in commande.ListeProduitsCom)
            {
                Produit p = Produit.GetProduitById(pc.Produit.Id);
                if(p.Quantity >= pc.Quantity)
                {
                    p.Quantity -= pc.Quantity;
                }
                else
                {
                    pc.Quantity = p.Quantity;
                    p.Quantity = 0;
                }
                DataContext.Instance.SaveChanges();
            }
            HttpContext.Session.Clear();
            return RedirectToAction("DetailCommande", commande);
        }

        [Authorize(Policy = "ConnectUser")]
        public IActionResult DetailCommande(int id)
        {
            Commande commande = new Commande();
            commande = Commande.GetCommandeById(id);
            return View(commande);
        }
    }
}
