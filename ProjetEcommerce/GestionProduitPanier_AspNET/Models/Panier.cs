using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Models
{
    public class Panier
    {
        int id;
        List<ProduitPanier> listeProduits;

        public List<ProduitPanier> ListeProduits { get => listeProduits; set => listeProduits = value; }
        public int Id { get => id; set => id = value; }

        public Panier()
        {
            ListeProduits = new List<ProduitPanier>();
        }

        public void AddProduit(Produit produit, int qty)
        {
            bool produitExist = false;
            foreach (ProduitPanier pp in ListeProduits)
            {
                if (pp.Produit.Id == produit.Id)
                {
                    pp.Quantity += qty;
                    produitExist = true;
                }
            }
            if (!produitExist)
            {
                ProduitPanier produitPanier = new ProduitPanier()
                {
                    Quantity = qty,
                    Produit = produit
                };
                ListeProduits.Add(produitPanier);
            }
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach(ProduitPanier pp in ListeProduits)
            {
                total += pp.Produit.Prix * pp.Quantity;
            }
            return total;
        }

        public bool DeleteProduit(int id)
        {
            ProduitPanier produitPanier = ListeProduits.FirstOrDefault(p => p.Produit.Id == id);
            //ListeProduits.RemoveAll(m => m.Produit.Id == id);
            if(produitPanier !=null)
            {
                ListeProduits.Remove(produitPanier);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
