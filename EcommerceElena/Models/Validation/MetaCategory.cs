using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceElena.Models
{
    [MetadataType(typeof(MetaCategory))]
    public partial class Category { }
    public class MetaCategory
    {
        public int idCategory { get; set; }

        [StringLength(30, ErrorMessage = "Nombre de charactères maximum est 30")]
        [Display(Name = "Categorie")]
        public string nomCategory { get; set; }
        public ICollection<Produit> Produits { get; set; }
    }
}