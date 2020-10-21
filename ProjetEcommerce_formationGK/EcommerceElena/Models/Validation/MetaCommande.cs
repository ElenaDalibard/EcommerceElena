using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceElena.Models
{
    [MetadataType(typeof(MetaCommande))]
    public partial class Commande { }
    public class MetaCommande
    {
        public int IdCommande { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? dateCommande { get; set; }
        public int idUser { get; set; }

        [DataType(DataType.Currency)]
        public double? PrixTotal { get; set; }

        public int statusCommande { get; set; }
        public User User { get; set; }
        public ICollection<DetailCommande> DetailCommandes { get; set; }
        public ICollection<Facture> Factures { get; set; }

    }
}