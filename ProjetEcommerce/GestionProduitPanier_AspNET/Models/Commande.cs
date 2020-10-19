using GestionProduitPanier_AspNET.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Models
{
    public class Commande
    {
        int id;
        List<ProduitCommande> listeProduitsCom;
        Utilisateur utilisateur;
        decimal total;
        DateTime date;

        public int Id { get => id; set => id = value; }
        public List<ProduitCommande> ListeProduitsCom { get => listeProduitsCom; set => listeProduitsCom = value; }
        public Utilisateur Utilisateur { get => utilisateur; set => utilisateur = value; }
        public decimal Total { get => total; set => total = value; }
        public DateTime Date { get => date; set => date = value; }

        public Commande()
        {
            ListeProduitsCom = new List<ProduitCommande>();
        }

        public virtual bool Save(Panier panier, Utilisateur user)
        {
            foreach (ProduitPanier pp in panier.ListeProduits)
            {
                ListeProduitsCom.Add(new ProduitCommande()
                {
                    Quantity = pp.Quantity,
                    Produit=Produit.GetProduitById(pp.Produit.Id)
                });
                Total += pp.Produit.Prix * pp.Quantity;
            }
            Utilisateur = user;
            Date = DateTime.Now;
            DataContext.Instance.Commandes.Add(this);
            DataContext.Instance.SaveChanges();
            return Id > 0;
        }

        public static Commande GetCommandeById(int id)
        {
            Commande commande = new Commande();
            commande = DataContext.Instance.Commandes.Include(a => a.ListeProduitsCom).ThenInclude(p=>p.Produit).FirstOrDefault(a => a.Id == id);
            return commande;
        }

        public static List<Commande> GetCommandeByClient(int id)
        {
            List<Commande> commandes = new List<Commande>();
            commandes = DataContext.Instance.Commandes.Include(a => a.ListeProduitsCom).ThenInclude(p => p.Produit).Where(a => a.Utilisateur.Id == id).ToList();
            return commandes;
        }

        public static List<Commande> GetCommandes()
        {
            List<Commande> liste = new List<Commande>();
            liste = DataContext.Instance.Commandes.Include(u=>u.Utilisateur).Include(a => a.ListeProduitsCom).ThenInclude(p=>p.Produit).ToList();
            return liste;
        }
    }
}
