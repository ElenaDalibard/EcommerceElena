using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceElena.DataAccess;
using EcommerceElena.Models;
using EcommerceElena.Outils;

namespace EcommerceElena.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        Repository<User> repUser = new EFRepository<User>();
        Repository<Commande> repCommande = new EFRepository<Commande>();

        public ActionResult _BestUsers()
        {
            var query = repCommande.Lister().GroupBy(x => x.idUser).Select(g => new { iduser = g.Key, prixtotal = g.Sum(x => x.PrixTotal) }).ToList().OrderByDescending(g => g.prixtotal);
            List<IdUserList> ListUser = new List<IdUserList>();
            foreach (var itemquery in query)
            {
                IdUserList item = new IdUserList();
                item.iduser = (int)itemquery.iduser;
                item.prixtotal = (int)itemquery.prixtotal;
                item.nomuser = repUser.Trouver(item.iduser).nomUser;
                item.prenomuser = repUser.Trouver(item.iduser).PrenomUser;
                item.emailuser = repUser.Trouver(item.iduser).emailUser;
                item.telephone = repUser.Trouver(item.iduser).telephoneUser;
                item.paysuser = repUser.Trouver(item.iduser).paysUser;
                item.villeuser = repUser.Trouver(item.iduser).villeUser;
                ListUser.Add(item);
            }
            BestListe model = new BestListe()
            {
                ListUsers = ListUser
            };
            return PartialView(model);
        }

        public ActionResult Index()
        {
            return View(repUser.Lister().OrderBy(u => u.statusUser));
        }

        //[GET] Avis
        public ActionResult DeposerAvis(int id)
        {
            Repository<Produit> repProd = new EFRepository<Produit>();
            Produit prod = new Produit();
            prod = repProd.Trouver(id);

            Avi newAvis = new Avi
            {
                idProd = id,
                idUser = ((User)Session["User"]).idUser,
                Produit = prod
            };
            
            
            
            return View(newAvis);
        }

        //[POST] Avis
        [HttpPost]
        public ActionResult DeposerAvis(Avi avis)
        {
            avis.dateAvis = DateTime.Today;
            avis.statusAvis = (int)StatusAvis.nonapprouvé;
            Repository<Avi> repAvis = new EFRepository<Avi>();
            repAvis.Ajouter(avis);
            return RedirectToAction("MesCommandes", new { id = avis.idUser });
        }

        [Authorize]
        public ActionResult MesCommandes()
        {
                int id = ((User)Session["User"]).idUser;
                return View(repCommande.Lister().Where(c => c.idUser == id).OrderBy(c => c.statusCommande));
        }

        public ActionResult DetailsCmd(int id)
        {
            return View(repCommande.Trouver(id));
        }


        //GET: Uesr/Details/5
        [Authorize]
        public ActionResult MonCompte()
        {
                int id = ((User)Session["User"]).idUser;
                return View(repUser.Trouver(id));
        }

        public ActionResult Details(int id)
        {
            return View(repUser.Trouver(id));
        }

        // GET: Uesr/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repUser.Trouver(id));
        }

        // POST: Uesr/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                repUser.Modifier(user);
                return RedirectToAction("MonCompte");
            }
            catch
            {
                return View();
            }
        }

        // GET: Uesr/Bloque/5
        public ActionResult Bloque(int id)
        {
            return View(repUser.Trouver(id));
        }

        // POST: Uesr/Bloque/5
        [HttpPost, ActionName("Bloque")]
        public ActionResult BloqueConfirm(int id)
        {
            try
            {
                User userBloque = repUser.Trouver(id);
                if (userBloque.statusUser == "bloque")
                {
                    userBloque.statusUser = null;
                }
                else
                {
                    userBloque.statusUser = "bloque";
                }
                repUser.Modifier(userBloque);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Uesr/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repUser.Trouver(id));
        }

        // POST: Uesr/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                repUser.Supprimer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
