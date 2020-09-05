using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceElena.Models
{
    [MetadataType(typeof(MetaRole))]
    public partial class Role { }
    public class MetaRole
    {
        
        public int idRole { get; set; }
        public string email { get; set; }
        public string roleNom { get; set; }
    }
}