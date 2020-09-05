using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceElena.DataAccess;
using EcommerceElena.Models;

namespace EcommerceElena.DataAcces
{
    public class CommandeRepository : EFRepository<Commande>
    {
        public override Commande Ajouter(Commande entite)
        {
            int iduser = entite.User.idUser;
            entite.User = null;
            entite.idUser = iduser;

            foreach(DetailCommande d in entite.DetailCommandes)
            {
                int? idproduit = d.idProd;
                d.Produit = null;
                d.idProd = idproduit;
            }
            entite.statusCommande = 1;
            return base.Ajouter(entite);
        }
    }
}
