namespace EcommerceElena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role 
    {
        [Key]
        public int idRole { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(15)]
        public string roleNom { get; set; }
    }
}
