namespace EcommerceElena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fournisseur")]
    public partial class Fournisseur 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fournisseur()
        {
            Produits = new HashSet<Produit>();
        }

        [Key]
        public int idFourn { get; set; }

        [Required]
        [StringLength(20)]
        public string nomFourn { get; set; }

        [StringLength(50)]
        public string emailFourn { get; set; }

        [StringLength(15)]
        public string telephoneFourn { get; set; }
        
        [StringLength(25)]
        public string paysFourn { get; set; }

        [StringLength(30)]
        public string villeFourn { get; set; }

        [StringLength(100)]
        public string adresseFourn { get; set; }

        public string codePostal { get; set; }

        public string descriptionFourn { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
