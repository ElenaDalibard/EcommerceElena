using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Models
{
    public class ProduitPanier
    {
        int id;
        Produit produit;
        int quantity;

        public int Id { get => id; set => id = value; }
        public Produit Produit { get => produit; set => produit = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
