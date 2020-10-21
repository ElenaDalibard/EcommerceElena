using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceElena.Models
{
    [MetadataType(typeof(MetaFacture))]
    public partial class Facture { }
    public class MetaFacture
    {
        public int idCommande { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? dateFacture { get; set; }
        public int idFacture { get; set; }

        [DataType(DataType.Currency)]
        public double? prixHT { get; set; }

        [DataType(DataType.Currency)]
        public double? prixLivraison { get; set; }

        [DataType(DataType.Currency)]
        public double? prixTotal { get; set; }

        [DataType(DataType.Currency)]
        public double? prixTVA { get; set; }
        public Commande Commande { get; set; }
    }
}