using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceElena.Models
{
    [MetadataType(typeof(MetaUser))]
    public partial class User { }
    public class MetaUser
    {
        public int idUser { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(20, ErrorMessage = "Nombre de charactères maximum est 20")]
        [Display(Name = "Nom")]
        public string nomUser { get; set; }

        [StringLength(20, ErrorMessage = "Nombre de charactères maximum est 20")]
        [Display(Name = "Prénom")]
        public string PrenomUser { get; set; }

        public string sexe { get; set; }

        [StringLength(30, ErrorMessage = "Nombre de charactères maximum est 30")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adresse e-mail")]
        public string emailUser { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numéro de téléphone")]
        public string telephoneUser { get; set; }

        [Display(Name = "Pays")]
        public string paysUser { get; set; }

        [StringLength(20)]
        [Display(Name = "Ville")]
        public string villeUser { get; set; }

        [StringLength(50, ErrorMessage = "Nombre de charactères maximum est 50")]
        [Display(Name = "Adresse")]
        public string adresseUser { get; set; }

        [StringLength(7, ErrorMessage = "Nombre de charactères maximum est 50")]
        [Display(Name = "Code postal")]
        public string codePostal { get; set; }

        [StringLength(10, ErrorMessage = "Nombre de charactères maximum est 10")]
        public string statusUser { get; set; }

        public ICollection<Avi> Avis { get; set; }
        public ICollection<Commande> Commandes { get; set; }
    }
}