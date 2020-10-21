using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceElena.Models
{
    [MetadataType(typeof(MetaProduit))]
    public partial class Produit { }
    public class MetaProduit
    {
        public int idProd { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(20, ErrorMessage = "Nombre de charactères maximum est 20")]
        [Display(Name = "Nom de produit")]
        public string nomProd { get; set; }

        [StringLength(50)]
        [DataType(DataType.ImageUrl)]
        public string imageUrl { get; set; }

        [Display(Name = "Poids, kg")]
        public double? poids { get; set; }

        [Display(Name = "Capacité en nombre de pièces de 1 €")]
        public int? capacite { get; set; }

        [StringLength(20, ErrorMessage = "Nombre de charactères maximum est 20")]
        [Display(Name = "Couleur principale")]
        public string couleur { get; set; }

        [Display(Name = "Hauteur")]
        public double? hauteur { get; set; }

        [Display(Name = "Largeur")]
        public double? largeur { get; set; }

        [Display(Name = "Longueur")]
        public double? longeur { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Prix")]
        public double? PrixProd { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(400, ErrorMessage = "Nombre de charactères maximum est 400")]
        [Display(Name = "Description du produit")]
        public string descriptionProd { get; set; }

        [Display(Name = "Fabricant")]
        public int? idFourn { get; set; }

        [Display(Name = "Categorie")]
        public int? idCategory { get; set; }

        [StringLength(20, ErrorMessage = "Nombre de charactères maximum est 20")]
        [Display(Name = "Statut")]
        public string statusProd { get; set; }

        public ICollection<Avi> Avis { get; set; }
        public ICollection<DetailCommande> DetailCommandes { get; set; }
        public Fournisseur Fournisseur { get; set; }
        public virtual Category Category { get; set; }
    }
}