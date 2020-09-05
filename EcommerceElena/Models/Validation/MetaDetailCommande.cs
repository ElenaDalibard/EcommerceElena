using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceElena.Models
{
    [MetadataType(typeof(MetaDetailCommande))]
    public partial class DetailCommande { }
    public class MetaDetailCommande
    {
        public int idDetCom { get; set; }
        public int? idCommande { get; set; }
        public int? idProd { get; set; }
        public int? quantite { get; set; }
        public Produit Produit { get; set; }
        public Commande Commande { get; set; }
    }
}