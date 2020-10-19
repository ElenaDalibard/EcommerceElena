using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Tools
{
    public class ConnectionRequirement:IAuthorizationRequirement
    {
        public string Role { get; set; }

        public ConnectionRequirement()
        {

        }

        public ConnectionRequirement(string role)
        {
            Role = role;
        }
    }
}
