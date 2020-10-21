using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceElena.Outils
{
    public enum  StatusCommande
    {
        inactive, 
        active, 
        preparée, 
        expediée, 
        livrée
    }

    public enum StatusAvis
    {
        rejeté, nonapprouvé, approuvé
    }
}