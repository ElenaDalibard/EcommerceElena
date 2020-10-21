namespace EcommerceElena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produit")]
    public partial class Produit 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produit()
        {
            Avis = new HashSet<Avi>();
            DetailCommandes = new HashSet<DetailCommande>();
        }

        [Key]
        public int idProd { get; set; }

        [Required]
        [StringLength(20)]
        public string nomProd { get; set; }

        [DataType(DataType.Currency)]
        public double? PrixProd { get; set; }

        [StringLength(20)]
        public string statusProd { get; set; }

        [StringLength(20)]
        public string couleur { get; set; }

        public int? capacite { get; set; }

        public double? poids { get; set; }

        public double? longeur { get; set; }

        public double? largeur { get; set; }

        public double? hauteur { get; set; }

        public int? idFourn { get; set; }

        public int? idCategory { get; set; }

        [StringLength(400)]
        public string descriptionProd { get; set; }

        [StringLength(50)]
        public string imageUrl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avi> Avis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailCommande> DetailCommandes { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }

        public virtual Category Category { get; set; }
    }
}
