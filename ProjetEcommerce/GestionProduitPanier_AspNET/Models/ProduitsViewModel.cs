using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Models
{
    public class ProduitsViewModel
    {
        public List<Produit> produits;
        public ProduitPanier produitPanier;

        public ProduitsViewModel()
        {
            produits = new List<Produit>();
            produitPanier = new ProduitPanier();
        }
    }
}
