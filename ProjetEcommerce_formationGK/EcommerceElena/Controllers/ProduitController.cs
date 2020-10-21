using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceElena.DataAccess;
using EcommerceElena.Models;
using System.IO;
using EcommerceElena.Outils;

namespace EcommerceElena.Controllers
{
    public class ProduitController : Controller
    {
        Repository<Produit> repProduit = new EFRepository<Produit>();

        Repository<DetailCommande> repDetailCommande = new EFRepository<DetailCommande>();

        public ActionResult _BestProduits()
        {
            var query = repDetailCommande.Lister().GroupBy(x => x.idProd).Select(g => new { idprod = g.Key, total = g.Sum(x => x.quantite) }).ToList().OrderByDescending(g => g.total);
            List<IdProdTotalVM> ListProd = new List<IdProdTotalVM>();
                foreach (var itemquery in query)
            {
                IdProdTotalVM item = new IdProdTotalVM();
                item.idprod = (int)itemquery.idprod;
                item.total=(int)itemquery.total;
                item.nomprod = repProduit.Trouver(item.idprod).nomProd;
                item.url = repProduit.Trouver(item.idprod).imageUrl;
                item.prix = repProduit.Trouver(item.idprod).PrixProd;
                ListProd.Add(item);
            }
            TopListe model = new TopListe()
            {
                ListProds = ListProd
            };
            return PartialView(model);
        }

        private void ListeFournisseurs()
        {
            Repository<Fournisseur> repFourn = new EFRepository<Fournisseur>();
            ViewBag.idFourn = repFourn.Lister().Select(f => new SelectListItem { Value = f.idFourn.ToString(), Text = f.nomFourn }).ToList<SelectListItem>();
        }

        private void ListeCategories()
        {
            Repository<Category> repCategory = new EFRepository<Category>();
            ViewBag.idCategory = repCategory.Lister().Select(c => new SelectListItem { Value = c.idCategory.ToString(), Text = c.nomCategory }).ToList<SelectListItem>();
        }

        // GET: Produit
        [Authorize]
        public ActionResult Index()
        {
            return View(repProduit.Lister().OrderBy(p=>p.statusProd));
        }

        public ActionResult Gallery()
        {
            return View(repProduit.Lister().Where(p=>p.statusProd==null));
        }

        public ActionResult _ColorGallery(int id, string color)
        {
            return PartialView(repProduit.Lister().Where(p => p.couleur == color && p.idProd !=id && p.statusProd == null).Take(4));
        }


        // GET: Produit/Details/5
        public ActionResult Details(int id)
        {
            return View(repProduit.Trouver(id));
        }

        // GET: Produit/Create
        [Authorize]
        public ActionResult Create()
        {
            ListeFournisseurs();
            ListeCategories();
            return View();
        }

        // POST: Produit/Create
        [HttpPost]
        public ActionResult Create(Produit produit, HttpPostedFileBase fichier)
        {
            try
            {
                if(fichier !=null)
                {
                    produit.imageUrl = Path.GetFileName(fichier.FileName);
                }
                Produit newProd = repProduit.Ajouter(produit);

                if(fichier !=null)
                    {
                    if (newProd.imageUrl != null)
                    {
                        string chemin = string.Format("{0}\\{1}_{2}", System.Web.Hosting.HostingEnvironment.MapPath("~/Images"), newProd.idProd, newProd.imageUrl);
                        fichier.SaveAs(chemin);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ListeCategories();
                ListeFournisseurs();
                return View();
            }
        }

        // GET: Produit/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            ListeCategories();
            ListeFournisseurs();
            return View(repProduit.Trouver(id));
        }

        // POST: Produit/Edit/5
        [HttpPost]
        public ActionResult Edit(Produit produit, HttpPostedFileBase fichier)
        {
            try
            {
                string oldNomFichier = produit.imageUrl;
                if (fichier != null)
                {
                    produit.imageUrl = Path.GetFileName(fichier.FileName);
                }
                Produit newProd = repProduit.Modifier(produit);

                if (fichier != null)
                {
                    if (newProd.imageUrl != null)
                    {
                        string oldFichier = string.Format("{0}\\{1}_{2}", Server.MapPath("~/Images"), newProd.idProd, oldNomFichier);

                        if (System.IO.File.Exists(oldFichier))
                        {
                            System.IO.File.Delete(oldFichier);
                        }
                    }

                    string destination = string.Format("{0}\\{1}_{2}", System.Web.Hosting.HostingEnvironment.MapPath("~/Images"), newProd.idProd, newProd.imageUrl);
                    fichier.SaveAs(destination);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ListeCategories();
                ListeFournisseurs();
                return View();
            }
        }

        // GET: Produit/Bloque/5
        [Authorize]
        public ActionResult Bloquer(int id)
        {
            return View(repProduit.Trouver(id));
        }

        // POST: Produit/Bloque/5
        [HttpPost, ActionName("Bloquer")]
        public ActionResult BloquerConfirm(int id)
        {
            try
            {
                Produit prodBloque = repProduit.Trouver(id);
                if (prodBloque.statusProd == "bloque")
                {
                    prodBloque.statusProd = null;
                }
                else
                {
                    prodBloque.statusProd = "bloque";
                }
                repProduit.Modifier(prodBloque);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produit/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(repProduit.Trouver(id));
        }

        // POST: Produit/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                repProduit.Supprimer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
