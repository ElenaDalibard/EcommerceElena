namespace EcommerceElena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Avi
    {
        [Key]
        public int idAvis { get; set; }

        public int? idUser { get; set; }

        public int idProd { get; set; }

        public DateTime? dateAvis { get; set; }
        public int? note { get; set; }

        [StringLength(200)]
        public string texte { get; set; }

        public int statusAvis { get; set; }

        public virtual Produit Produit { get; set; }

        public virtual User User { get; set; }
    }
}
