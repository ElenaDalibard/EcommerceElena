using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceElena.Models
{
    [MetadataType(typeof(MetaFournisseur))]
    public partial class Fournisseur { }
    public class MetaFournisseur
    {
        public int idFourn { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(20, ErrorMessage = "Nombre de charactères maximum est 20")]
        [Display(Name = "Nom du fabricant")]
        public string nomFourn { get; set; }

        [StringLength(50, ErrorMessage = "Nombre de charactères maximum est 50")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Addresse e-mail")]
        public string emailFourn { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numéro de téléphone")]
        public string telephoneFourn { get; set; }

        [StringLength(25, ErrorMessage = "Nombre de charactères maximum est 25")]
        [Display(Name = "Pays")]
        public string paysFourn { get; set; }

        [StringLength(30, ErrorMessage = "Nombre de charactères maximum est 30")]
        [Display(Name = "Ville")]
        public string villeFourn { get; set; }

        [StringLength(100, ErrorMessage = "Nombre de charactères maximum est 100")]
        [Display(Name = "Adresse")]
        public string adresseFourn { get; set; }

        [StringLength(7, ErrorMessage = "Nombre de charactères maximum est 7")]
        [Display(Name = "Code postal")]
        public string codePostal { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(400)]
        [Display(Name = "Description du fabricant")]
        public string descriptionFourn { get; set; }

        [StringLength(10, ErrorMessage = "Nombre de charactères maximum est 10")]
        [Display(Name = "Statut")]
        public string status { get; set; }

        public ICollection<Produit> Produits { get; set; }
    }
}