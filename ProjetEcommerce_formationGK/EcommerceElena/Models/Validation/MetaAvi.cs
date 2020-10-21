using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceElena.Models

{
    [MetadataType(typeof(MetaAvi))]
    public partial class Avi { }

    public class MetaAvi
    {
        public int idAvis { get; set; }
        public int idProd { get; set; }
        public int? idUser { get; set; }

        [Display(Name = "Note pour le produit")]
        public int? note { get; set; }

        public int statusAvis { get; set; }

        [StringLength(200, ErrorMessage = "Nombre de charactères maximum est 100")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Texte de commentaire")]
        public string texte { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? dateAvis { get; set; }
        public Produit Produit { get; set; }
        public User User { get; set; }
    }
}