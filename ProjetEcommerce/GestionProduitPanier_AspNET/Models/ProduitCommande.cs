using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Models
{
    public class ProduitCommande
    {
        int id;
        int quantity;
        Produit produit;

        public int Quantity { get => quantity; set => quantity = value; }
        public Produit Produit { get => produit; set => produit = value; }
        public int Id { get => id; set => id = value; }
    }
}
