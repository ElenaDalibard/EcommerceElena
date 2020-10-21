using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceElena.DataAccess;
using EcommerceElena.Models;

namespace EcommerceElena.Controllers
{
    public class FournisseurController : Controller
    {
        Repository<Fournisseur> repFournisseur = new EFRepository<Fournisseur>();

        // GET: Fournisseur
        public ActionResult Index()
        {
            return View(repFournisseur.Lister());
        }

        public ActionResult FiltreFourn()
        {
            return View("Index", repFournisseur.Lister().Where(f=>f.status != "bloque"));
        }

        // GET: Fournisseur/Details/5
        public ActionResult Details(int id)
        {
            return View(repFournisseur.Trouver(id));
        }

        // GET: Fournisseur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fournisseur/Create
        [HttpPost]
        public ActionResult Create(Fournisseur fournisseur)
        {
            try
            {
                repFournisseur.Ajouter(fournisseur);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repFournisseur.Trouver(id));
        }

        // POST: Fournisseur/Edit/5
        [HttpPost]
        public ActionResult Edit(Fournisseur fournisseur)
        {
            try
            {
                repFournisseur.Modifier(fournisseur);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Bloquer/5
        public ActionResult Bloquer(int id)
        {
            return View(repFournisseur.Trouver(id));
        }

        // POST: Fournisseur/Bloquer/5
        [HttpPost, ActionName("Bloquer")]
        public ActionResult BloquerConfirm(int id)
        {
            try
            {
                Fournisseur fournBloque = repFournisseur.Trouver(id);
                if(fournBloque.status == "bloque")
                {
                    fournBloque.status = null;
                }
                else
                {
                    fournBloque.status = "bloque";
                }
                repFournisseur.Modifier(fournBloque);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repFournisseur.Trouver(id));
        }

        // POST: Fournisseur/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                repFournisseur.Supprimer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
